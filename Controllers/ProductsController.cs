using System;
using System.Collections.Generic;
using System.Linq;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommonShop.WebApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProduct(Guid productId)
        {
            var product = _productService
                .GetProducts()
                .SingleOrDefault(p => p.Id == productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}