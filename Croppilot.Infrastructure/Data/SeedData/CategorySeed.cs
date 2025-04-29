namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class CategorySeed
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                  new Category { Id = 1, Name = "Fresh Vegetables", Description = "Daily harvested organic vegetables", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/0bdbd4c8-2503-427c-b4fe-ffa6e5c57a23_Fresh Vegetables.jpg" },
                  new Category { Id = 2, Name = "Seasonal Fruits", Description = "Naturally grown fruits with authentic flavors", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/5caaf20a-3510-4d38-b2b4-b16e79cf45ab_Seasonal Fruits.jpg" },
                  new Category { Id = 3, Name = "Dairy Products", Description = "Fresh cheese and milk from our farm", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/61cd1282-c3c4-4ef3-9b2c-ae7d5beb482c_Dairy Products.jpg" },
                  new Category { Id = 4, Name = "Organic Eggs", Description = "Free-range chicken eggs", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/b7f5884a-6833-43f0-bb78-367c371a37fb_Organic Eggs.jpg" },
                  new Category { Id = 5, Name = "Ornamental Plants", Description = "Home garden flowers and decorative plants", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/9aa3dfb7-12b7-4631-908c-eb11fa0c64f9_Ornamental Plants.jpg" },
                  new Category { Id = 6, Name = "Seedlings", Description = "Vegetable and fruit starters for home gardening", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/28773f2f-5619-406e-8c74-1cd82b296d3f_Seedlings.jpg" },
                  new Category { Id = 7, Name = "Organic Animal Feed", Description = "Natural feed for livestock and poultry", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/a5a834c1-736c-4858-95df-673e21014525_Organic Animal Feed.jpg" },
                  new Category { Id = 8, Name = "Farming Tools", Description = "Essential agricultural equipment", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/c10224a6-0625-41a3-8332-73433f96f39e_Farming Tools.jpg" },
                  new Category { Id = 9, Name = "Premium Seeds", Description = "Certified high-yield seeds", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/6c4bef01-1181-4fde-8bc4-78331a8c82d2_Premium Seeds.jpg" },
                  new Category { Id = 10, Name = "Organic Fertilizers", Description = "Natural soil enhancers", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/242d456f-5b41-4d3a-8744-cd18ec583aae_Organic Fertilizers.jpg" }
              );
        }
    }
}
