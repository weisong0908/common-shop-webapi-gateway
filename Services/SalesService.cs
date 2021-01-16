using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CommonShop.WebApiGateway.Helpers;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;

namespace CommonShop.WebApiGateway.Services
{
    public class SalesService : ISalesService
    {
        IEnumerable<Product> _products;
        IEnumerable<Order> _orders;
        IEnumerable<Address> _addresses;
        IEnumerable<Customer> _customers;
        IEnumerable<Fee> _fees;
        private readonly IHttpClientFactory _httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            _products = SeedData.GetProducts();
            _orders = SeedData.GetOrders();
            _addresses = SeedData.GetAddresses();
            _customers = SeedData.GetCustomers();
            _fees = SeedData.GetFees();

            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("sales service");
            var response = await client.GetAsync("products");

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
            var response = await client.GetAsync($"products/{productId.ToString()}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer
                    .Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return product;
            }

            return null;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public Order GetOrder(Guid orderId)
        {
            return _orders.SingleOrDefault(o => o.Id == orderId);
        }

        public Order CreateOrder(OrderCreation orderCreation)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now
            };

            order.Customer = orderCreation.CustomerId;
            order.OrderStatus = OrderStatus.New;
            order.Products = orderCreation.Products.Select(p => p.Id);
            order.ShippingAddress = orderCreation.AddressId;
            order.TotalPrice = orderCreation.Products.Sum(p => p.Price * p.Quantity);

            return order;
        }

        public Address GetAddress(Guid id)
        {
            return _addresses.SingleOrDefault(a => a.Id == id);
        }

        public Customer GetCustomer(Guid id)
        {
            return _customers.SingleOrDefault(a => a.Id == id);
        }

        public Fee GetFee(Guid id)
        {
            return _fees.SingleOrDefault(a => a.Id == id);
        }
    }
}