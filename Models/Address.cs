using System;

namespace CommonShop.WebApiGateway.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
    }
}