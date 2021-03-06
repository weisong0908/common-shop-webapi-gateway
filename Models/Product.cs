using System;

namespace CommonShop.WebApiGateway.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string ThumbnailUrl { get; set; }
        public int StockLevel { get; set; }
    }
}