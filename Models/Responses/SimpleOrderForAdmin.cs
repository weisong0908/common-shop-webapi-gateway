using System;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class SimpleOrderForAdmin
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
    }
}