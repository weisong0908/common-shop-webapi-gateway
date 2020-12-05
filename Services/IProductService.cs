using System.Collections.Generic;
using CommonShop.WebApiGateway.Models;

namespace CommonShop.WebApiGateway.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}