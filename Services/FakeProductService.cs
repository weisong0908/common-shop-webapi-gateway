using System;
using System.Collections.Generic;
using CommonShop.WebApiGateway.Models;

namespace CommonShop.WebApiGateway.Services
{
    public class FakeProductService : IProductService
    {
        public FakeProductService()
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            var random = new Random();
            var products = new List<Product>();

            var guids = new List<Guid>()
            {
                new Guid("de039434-d200-43b9-8191-79869c895821"),
                new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"),
                new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"),
                new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"),
                new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"),
                new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"),
                new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"),
                new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"),
                new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"),
                new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"),
            };

            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product()
                {
                    Id = guids[i - 1],
                    Title = "Product " + i,
                    Description = "Some description",
                    Price = i * 10,
                    Category = i % 2 == 0 ? "Category 2" : "Category 1",
                    ThumbnailUrl = "https://bulma.io/images/placeholders/640x480.png"
                });
            }

            return products;
        }
    }
}