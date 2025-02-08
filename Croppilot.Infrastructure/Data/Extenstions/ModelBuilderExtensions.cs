using Croppilot.Date.Enum;

namespace Croppilot.Infrastructure.Data.Extenstions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Categories 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Seeds", Description = "High-quality seeds for farming" },
                new Category { Id = 2, Name = "Fertilizers", Description = "Organic and chemical fertilizers" },
                new Category { Id = 3, Name = "Farming Equipment", Description = "Tractors, plows, and other farming tools" }
            );

            // Seed Products 
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wheat Seeds",
                    Description = "High-yield wheat seeds suitable for all climates",
                    Price = 19.99m,
                    Availability = Availability.Sale,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Organic Fertilizer",
                    Description = "Natural compost-based fertilizer for better crop growth",
                    Price = 49.99m,
                    Availability = Availability.Sale,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Mini Tractor",
                    Description = "Compact tractor for small to medium-sized farms",
                    Price = 4999.99m,
                    Availability = Availability.Lease,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 3
                }
            );

            // Seed Product Images
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, ImageUrl = "https://example.com/wheat-seeds.jpg", ProductId = 1 },
                new ProductImage { Id = 2, ImageUrl = "https://example.com/organic-fertilizer.jpg", ProductId = 2 },
                new ProductImage { Id = 3, ImageUrl = "https://example.com/mini-tractor.jpg", ProductId = 3 }
            );
        }
    }

}
