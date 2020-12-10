using System;

namespace CommonShop.WebApiGateway.Models
{
    public class Fee
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
    }
}