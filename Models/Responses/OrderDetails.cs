using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public Address ShippingAddress { get; set; }
        public IEnumerable<Fee> Fees { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
    }
}