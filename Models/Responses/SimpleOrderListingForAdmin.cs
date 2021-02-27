using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class SimpleOrderListingForAdmin
    {
        public IEnumerable<SimpleOrderForAdmin> Orders { get; set; }
        public int TotalOrderCount { get; set; }
    }
}