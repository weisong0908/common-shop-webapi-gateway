using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Requests;

namespace CommonShop.WebApiGateway.Services
{
    public interface ISalesService
    {
        Task<int> GetTotalProductCount(string category = "");
        Task<IEnumerable<Product>> GetProducts(int take, int skip = 0, string category = "");
        Task<Product> GetProduct(Guid productId);
        Task UpdateProduct(ProductModification product);
        Task<Product> CreateProduct(ProductModification product);
        Task DeleteProduct(Guid productId);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid orderId);
    }
}