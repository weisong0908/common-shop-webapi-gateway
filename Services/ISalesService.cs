using System;
using System.Collections.Generic;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;

namespace CommonShop.WebApiGateway.Services
{
    public interface ISalesService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid productId);
        IEnumerable<Order> GetOrders();
        Order GetOrder(Guid orderId);
        Order CreateOrder(OrderCreation orderCreation);
    }
}