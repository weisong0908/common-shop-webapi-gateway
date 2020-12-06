using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}