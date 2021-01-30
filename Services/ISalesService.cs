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
        Task UpdateProduct(Product product);
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(Guid productId);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid orderId);
    }
}