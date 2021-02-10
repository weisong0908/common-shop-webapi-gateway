using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;
using CommonShop.WebApiGateway.Models.Responses;
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
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, ISalesService salesService, IWarehouseService warehouseService, IMapper mapper)
        {
            _logger = logger;
            _salesService = salesService;
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] string category)
        {
            var products = await _salesService.GetProducts(pageSize, (pageNumber - 1) * pageSize, category);

            var totalProductCount = await _salesService.GetTotalProductCount(category);

            foreach (var product in products)
                product.StockLevel = _warehouseService.GetStockLevel(product.Id);

            var response = new DetailedProductListing()
            {
                Products = _mapper.Map<IEnumerable<DetailedProduct>>(products),
                TotalProductCount = totalProductCount
            };

            return Ok(response);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _salesService.GetProduct(productId);

            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<DetailedProduct>(product));
        }

        [HttpPut("{productId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateProduct(Guid productId, ProductModification productModification)
        {
            if (productId != productModification.Id)
                return BadRequest();

            try
            {
                await _salesService.UpdateProduct(productModification);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateProduct(ProductModification productModification)
        {
            Product productCreated;

            try
            {
                productCreated = await _salesService.CreateProduct(productModification);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetProduct), new { productId = productCreated.Id }, productCreated);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            try
            {
                await _salesService.DeleteProduct(productId);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var productCategories = await _salesService.GetProductCategories();

            _logger.LogInformation($"{productCategories.Count()} productCategories found");

            return Ok(productCategories);
        }
    }
}