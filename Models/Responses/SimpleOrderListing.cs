using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class SimpleOrderListing
    {
        public IEnumerable<SimpleOrder> Orders { get; set; }
        public int TotalOrderCount { get; set; }
    }
}