namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class ProductImageSeed
    {
        public static void SeedProductImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, ImageUrl = "https://example.com/image1.jpg", ProductId = 1 },
                new ProductImage { Id = 2, ImageUrl = "https://example.com/image2.jpg", ProductId = 2 },
                new ProductImage { Id = 3, ImageUrl = "https://example.com/image3.jpg", ProductId = 3 },
                new ProductImage { Id = 4, ImageUrl = "https://example.com/image4.jpg", ProductId = 4 },
                new ProductImage { Id = 5, ImageUrl = "https://example.com/image5.jpg", ProductId = 5 }
            );
        }
    }
}
