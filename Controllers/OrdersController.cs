using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonShop.WebApiGateway.Models.Requests;
using CommonShop.WebApiGateway.Models.Responses;
using CommonShop.WebApiGateway.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommonShop.WebApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISalesService _salesService;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(ISalesService salesService, ILogger<OrdersController> logger, IMapper mapper)
        {
            _salesService = salesService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSimpleOrders()
        {
            var orders = await _salesService.GetOrders();

            var simpleOrders = _mapper.Map<IEnumerable<SimpleOrder>>(orders);

            return Ok(simpleOrders);
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetSimpleOrdersWithStatus()
        {
            var orders = await _salesService.GetOrders();

            var simpleOrders = _mapper.Map<IEnumerable<SimpleOrderForAdmin>>(orders);

            return Ok(simpleOrders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var order = await _salesService.GetOrder(orderId);

            if (order == null)
                return NotFound();

            var detailedOrder = _mapper.Map<DetailedOrder>(order);
            return Ok(detailedOrder);
        }
    }
}