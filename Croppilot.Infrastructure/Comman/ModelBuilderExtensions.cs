using Croppilot.Date.Enum;

namespace Croppilot.Infrastructure.Comman
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Categories 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 20, Name = "Seeds", Description = "High-quality seeds for farming" },
                new Category { Id = 21, Name = "Fertilizers", Description = "Organic and chemical fertilizers" },
                new Category { Id = 22, Name = "Farming Equipment", Description = "Tractors, plows, and other farming tools" }
            );

            // Seed Products 
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 20,
                    Name = "Wheat Seeds",
                    Description = "High-yield wheat seeds suitable for all climates",
                    Price = 19.99m,
                    Availability = Availability.Sale,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 20,
                    UserId = "0327f49b-b4dd-4157-b767-1b1f4d50ee00"
                },
                new Product
                {
                    Id = 21,
                    Name = "Organic Fertilizer",
                    Description = "Natural compost-based fertilizer for better crop growth",
                    Price = 49.99m,
                    Availability = Availability.Sale,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 21,
                    UserId = "0327f49b-b4dd-4157-b767-1b1f4d50ee00"
                },
                new Product
                {
                    Id = 22,
                    Name = "Mini Tractor",
                    Description = "Compact tractor for small to medium-sized farms",
                    Price = 4999.99m,
                    Availability = Availability.Lease,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 22,
                    UserId = "0327f49b-b4dd-4157-b767-1b1f4d50ee00"
                },
                new Product
                {
                    Id = 23,
                    Name = "Tomato Seeds",
                    Description = "High-quality tomato seeds for high-yield crops",
                    Price = 15.99m,
                    Availability = Availability.Sale,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 20,
                    UserId = "0327f49b-b4dd-4157-b767-1b1f4d50ee00"
                },
                new Product
                {
                    Id = 24,
                    Name = "Chemical Fertilizer",
                    Description = "Boosts plant growth with essential nutrients",
                    Price = 39.99m,
                    Availability = Availability.Sale,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 21,
                    UserId = "0327f49b-b4dd-4157-b767-1b1f4d50ee00"
                }
            );

            // Seed Product Images
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 20, ImageUrl = "https://example.com/wheat-seeds.jpg", ProductId = 20 },
                new ProductImage { Id = 21, ImageUrl = "https://example.com/organic-fertilizer.jpg", ProductId = 21 },
                new ProductImage { Id = 22, ImageUrl = "https://example.com/mini-tractor.jpg", ProductId = 22 },
                new ProductImage { Id = 23, ImageUrl = "https://example.com/tomato-seeds.jpg", ProductId = 23 },
                new ProductImage { Id = 24, ImageUrl = "https://example.com/chemical-fertilizer.jpg", ProductId = 24 }
            );
        }
    }
}
