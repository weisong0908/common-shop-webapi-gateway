using System;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}