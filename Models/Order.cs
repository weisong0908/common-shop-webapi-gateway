using System;
using System.Collections.Generic;

namespace CommonShop.WebApiGateway.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public IList<Fee> Fees { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
    }
}