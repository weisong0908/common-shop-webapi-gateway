using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;

namespace CommonShop.WebApiGateway.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("sales service");
            var response = await client.GetAsync("/products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer
                    .Deserialize<IEnumerable<Product>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return products;
            }

            return null;
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            var client = _httpClientFactory.CreateClient("sales service");
            var response = await client.GetAsync($"/products/{productId.ToString()}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer
                    .Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return product;
            }

            return null;
        }

        public async Task UpdateProduct(ProductModification product)
        {
            var client = _httpClientFactory.CreateClient("sales service");

            var httpContent = new StringContent(JsonSerializer.Serialize<ProductModification>(product), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await client.PutAsync($"/products/{product.Id.ToString()}", httpContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Product> CreateProduct(ProductModification product)
        {
            var client = _httpClientFactory.CreateClient("sales service");

            var httpContent = new StringContent(JsonSerializer.Serialize<ProductModification>(product), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await client.PostAsync($"/products", httpContent);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer
                .Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task DeleteProduct(Guid productId)
        {
            var client = _httpClientFactory.CreateClient("sales service");

            var response = await client.DeleteAsync($"/products/{productId.ToString()}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var client = _httpClientFactory.CreateClient("sales service");
            var response = await client.GetAsync("/products/categories");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productCategories = JsonSerializer
                    .Deserialize<IEnumerable<ProductCategory>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return productCategories;
            }

            return null;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var client = _httpClientFactory.CreateClient("sales service");
            var response = await client.GetAsync("/orders");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer
                    .Deserialize<IEnumerable<Order>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });
                return orders;
            }

            return null;
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            var client = _httpClientFactory.CreateClient("sales service");
            var response = await client.GetAsync($"/orders/{orderId.ToString()}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var order = JsonSerializer
                    .Deserialize<Order>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return order;
            }

            return null;
        }
    }
}