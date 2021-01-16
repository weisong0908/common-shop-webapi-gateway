using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;

namespace CommonShop.WebApiGateway.Services
{
    public interface ISalesService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid productId);
        IEnumerable<Order> GetOrders();
        Order GetOrder(Guid orderId);
        Order CreateOrder(OrderCreation orderCreation);
        Address GetAddress(Guid id);
        Customer GetCustomer(Guid id);
        Fee GetFee(Guid id);
    }
}