using System;

namespace CommonShop.WebApiGateway.Models.Requests
{
    public class ProductModification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ThumbnailUrl { get; set; }
        public int StockLevel { get; set; }
    }
}