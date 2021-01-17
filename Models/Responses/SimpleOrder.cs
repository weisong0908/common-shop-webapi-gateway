using System;

namespace CommonShop.WebApiGateway.Models.Responses
{
    public class SimpleOrder
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}