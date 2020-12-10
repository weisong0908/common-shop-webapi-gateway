using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Guid> Products { get; set; }
        public Guid Customer { get; set; }
        public Guid ShippingAddress { get; set; }
        public IEnumerable<Guid> Fees { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}