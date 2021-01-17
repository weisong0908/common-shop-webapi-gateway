using System;
using System.Text.Json.Serialization;

namespace CommonShop.WebApiGateway.Models
{
    public class OrderProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}