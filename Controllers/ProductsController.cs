using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
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
        private readonly ISalesService _salesService;
        private readonly IWarehouseService _warehouseService;

        public ProductsController(ILogger<ProductsController> logger, ISalesService salesService, IWarehouseService warehouseService)
        {
            _salesService = salesService;
            _warehouseService = warehouseService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _salesService.GetProducts();

            foreach (var product in products)
                product.StockLevel = _warehouseService.GetStockLevel(product.Id);

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _salesService.GetProduct(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut("{productId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateProduct(Guid productId, Product product)
        {
            if (productId != product.Id)
                return BadRequest();

            try
            {
                await _salesService.UpdateProduct(product);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            Product productCreated;

            try
            {
                productCreated = await _salesService.CreateProduct(product);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetProduct), new { productId = productCreated.Id }, productCreated);
        }
    }
}