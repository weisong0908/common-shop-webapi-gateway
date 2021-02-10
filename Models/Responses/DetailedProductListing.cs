using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class DetailedProductListing
    {
        public IEnumerable<DetailedProduct> Products { get; set; }
        public int TotalProductCount { get; set; }
    }
}