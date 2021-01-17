using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class DetailedOrder
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public IList<OrderItem> Products { get; set; }
        public Customer Customer { get; set; }
        public Address ShippingAddress { get; set; }
        public IList<Fee> Fees { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
    }
}