using System;

namespace CommonShop.WebApiGateway.Services
{
    public interface IWarehouseService
    {
        int GetStockLevel(Guid productId);
    }
}