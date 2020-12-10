using System;
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
        public IActionResult GetOrders()
        {
            var orders = _salesService.GetOrders();

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrder(Guid orderId)
        {
            var order = _salesService.GetOrder(orderId);

            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}