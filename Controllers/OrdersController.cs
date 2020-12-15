using System;
using System.Linq;
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

            var orderDetails = new OrderDetails();
            orderDetails.Id = order.Id;
            orderDetails.Date = order.Date;
            orderDetails.Customer = _salesService.GetCustomer(order.Customer);
            orderDetails.Fees = order.Fees.Select(f => _salesService.GetFee(f));
            orderDetails.OrderStatus = order.OrderStatus.ToString();
            orderDetails.Products = order.Products.Select(p => _salesService.GetProduct(p));
            orderDetails.ShippingAddress = _salesService.GetAddress(order.ShippingAddress);
            orderDetails.TotalQuantity = orderDetails.Products.Sum(p => p.Quantity);
            orderDetails.TotalPrice = order.TotalPrice;

            return Ok(orderDetails);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderCreation orderCreation)
        {
            var order = _salesService.CreateOrder(orderCreation);

            return CreatedAtAction(nameof(GetOrder), new { orderId = order.Id }, order);
        }
    }
}