using System;
using System.Collections.Generic;
using CommonShop.WebApiGateway.Models;

namespace CommonShop.WebApiGateway.Helpers
{
    public static class SeedData
    {
        public static IList<Product> GetProducts()
        {
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

        public static IList<Order> GetOrders()
        {
            var orders = new List<Order>();

            var guids = new List<Guid>()
            {
                new Guid("e148921a-f292-4078-8004-120a392836ab"),
                new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"),
                new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"),
                new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c")
            };

            for (int i = 0; i < 4; i++)
            {
                var order = new Order()
                {
                    Id = guids[i],
                    Date = DateTime.Today.AddDays(-i),
                    Products = new List<Guid>() { GetProducts()[i].Id, GetProducts()[i + 1].Id },
                    Customer = GetCustomers()[i].Id,
                    ShippingAddress = GetAddresses()[i].Id,
                    Fees = new List<Guid>() { GetFees()[0].Id },
                    OrderStatus = OrderStatus.New
                };
                order.TotalPrice = GetProducts()[i].Price + GetProducts()[i + 1].Price + GetFees()[0].Cost;

                orders.Add(order);
            }

            return orders;
        }

        public static IList<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            var guids = new List<Guid>()
            {
                new Guid("6865a7fa-6866-4516-9002-53cc8386991e"),
                new Guid("f5f1e765-a3bb-44bb-89b9-52ab8eab9db4"),
                new Guid("3a538afc-1441-4c96-bf86-81a18ad0ca04"),
                new Guid("97bdd552-ae59-403a-ba6c-3162d17560ec")
            };

            for (int i = 0; i < 4; i++)
            {
                var customer = new Customer()
                {
                    Id = guids[i],
                    Name = "John",
                    Phone = "98765432",
                    Email = "weisong0908@gmail.com",
                    Addresses = new List<Guid>() { GetAddresses()[i].Id },
                    PrimaryAddress = GetAddresses()[i].Id
                };

                customers.Add(customer);
            }

            return customers;
        }

        public static IList<Address> GetAddresses()
        {
            var addresses = new List<Address>();

            var guids = new List<Guid>()
            {
                new Guid("108e7c96-ea21-44f2-9cbe-db4237c2d1dd"),
                new Guid("41881c20-df28-43df-8e1c-e42748181ea3"),
                new Guid("5df7c00b-3cfd-48e7-a674-6aee0f120313"),
                new Guid("c9871377-210e-4979-a006-a8e156b05147")
            };

            for (int i = 0; i < 4; i++)
            {
                var address = new Address()
                {
                    Id = guids[i],
                    Line1 = $"Block {i} Street {i * 2}",
                    Line2 = $"#{10 - i}-{i * i}",
                    PostalCode = "123456"
                };

                addresses.Add(address);
            }

            return addresses;
        }

        public static IList<Fee> GetFees()
        {
            var fees = new List<Fee>();

            var guids = new List<Guid>()
            {
                new Guid("132898f9-ef64-474b-884c-d0b7801e9269"),
            };

            var fee = new Fee()
            {
                Id = guids[0],
                Title = "Shipping fee",
                Cost = 2
            };

            fees.Add(fee);

            return fees;
        }
    }
}