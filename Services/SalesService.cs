using System;
using System.Collections.Generic;
using System.Linq;
using CommonShop.WebApiGateway.Helpers;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;

namespace CommonShop.WebApiGateway.Services
{
    public class SalesService : ISalesService
    {
        IEnumerable<Product> _products;
        IEnumerable<Order> _orders;

        public SalesService()
        {
            _products = SeedData.GetProducts();
            _orders = SeedData.GetOrders();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(Guid productId)
        {
            return _products.SingleOrDefault(p => p.Id == productId);
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
    }
}