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
        Task UpdateProduct(ProductModification product);
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(Guid productId);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid orderId);
    }
}