using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Guid> Addresses { get; set; }
        public Guid PrimaryAddress { get; set; }
    }
}