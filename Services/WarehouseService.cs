using System;

namespace CommonShop.WebApiGateway.Services
{
    public class WarehouseService : IWarehouseService
    {
        public WarehouseService()
        {

        }

        public int GetStockLevel(Guid productId)
        {
            return 10;
        }
    }
}