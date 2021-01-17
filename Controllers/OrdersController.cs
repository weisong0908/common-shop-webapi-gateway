using System;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ILogger<OrdersController> _logger;
        private readonly ISalesService _salesService;

        public OrdersController(ILogger<OrdersController> logger, ISalesService salesService)
        {
            _logger = logger;
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _salesService.GetOrders();

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var order = await _salesService.GetOrder(orderId);

            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}