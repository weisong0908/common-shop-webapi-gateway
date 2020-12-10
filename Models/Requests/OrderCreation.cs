using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models.Requests
{
    public class OrderCreation
    {
        public IEnumerable<Product> Products { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
    }
}