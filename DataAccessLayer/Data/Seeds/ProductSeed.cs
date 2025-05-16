using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Data.Seeds
{
    public static class ProductSeed
    {
        public static DataBuilder GenerateProductSeed(this EntityTypeBuilder entity)
        {
            Product[] productSeed = [
                new Product
                {
                    Id = 1,
                    Name = "Grilled Chicken",
                    Description = "Tender grilled chicken breast with herbs.",
                    Price = 8.99,
                    CategoryId = 1,
                    CreationDate = new DateTime(2025, 04, 22)
                },
                new Product
                {
                    Id = 2,
                    Name = "Orange Juice",
                    Description = "Freshly squeezed orange juice.",
                    Price = 3.50,
                    CategoryId = 2,
                    CreationDate = new DateTime(2025, 04, 22)
                },
                new Product
                {
                    Id = 3,
                    Name = "Potato Chips",
                    Description = "Crispy salted potato chips.",
                    Price = 1.75,
                    CategoryId = 3,
                    CreationDate = new DateTime(2025, 04, 22)
                },
                new Product
                {
                    Id = 4,
                    Name = "Chocolate Cake",
                    Description = "Rich and moist chocolate layer cake.",
                    Price = 4.25,
                    CategoryId = 4,
                    CreationDate = new DateTime(2025, 04, 22)
                }
            ];
            return entity.HasData(productSeed);
        }
    }
}
