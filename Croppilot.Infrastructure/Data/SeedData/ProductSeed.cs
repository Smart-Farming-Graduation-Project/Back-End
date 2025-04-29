using Croppilot.Date.Enum;

namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class ProductSeed
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                  new Product
                  {
                      Id = 1,
                      Name = "Organic Tomatoes",
                      Description = "Fresh vine-ripened tomatoes",
                      Price = 19.99m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 1
                  },
                  new Product
                  {
                      Id = 2,
                      Name = "Cucumbers",
                      Description = "Crisp and refreshing cucumbers",
                      Price = 12.50m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 1
                  },
                  new Product
                  {
                      Id = 3,
                      Name = "Bell Peppers",
                      Description = "Mixed color sweet peppers",
                      Price = 18.75m,
                      Availability = Availability.Lease,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 1
                  },
                  new Product
                  {
                      Id = 4,
                      Name = "Strawberries",
                      Description = "Sweet and juicy strawberries",
                      Price = 25.99m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 2
                  },
                  new Product
                  {
                      Id = 5,
                      Name = "Mangoes",
                      Description = "Premium imported mangoes",
                      Price = 30.50m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 2
                  },
                  new Product
                  {
                      Id = 6,
                      Name = "Watermelons",
                      Description = "Large sweet watermelons",
                      Price = 45.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 2
                  },
                   new Product
                   {
                       Id = 7,
                       Name = "Farm Fresh Milk",
                       Description = "Whole milk 1L bottle",
                       Price = 20.00m,
                       Availability = Availability.Sale,
                       CreatedAt = DateTime.UtcNow,
                       UpdatedAt = DateTime.UtcNow,
                       UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                       CategoryId = 3
                   },
                  new Product
                  {
                      Id = 8,
                      Name = "Artisan Cheese",
                      Description = "Aged cheddar cheese 200g",
                      Price = 35.75m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 3
                  },
                  new Product
                  {
                      Id = 9,
                      Name = "Natural Yogurt",
                      Description = "Natural Yogurt",
                      Price = 18.50m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 3
                  },
                  new Product
                  {
                      Id = 10,
                      Name = "Free-Range Eggs (12pk)",
                      Description = "Large brown eggs",
                      Price = 30.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 4
                  },
                   new Product
                   {
                       Id = 11,
                       Name = "Rose Bush",
                       Description = "Red rose plant in 12\" pot",
                       Price = 120.00m,
                       Availability = Availability.Sale,
                       CreatedAt = DateTime.UtcNow,
                       UpdatedAt = DateTime.UtcNow,
                       UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                       CategoryId = 5
                   },
                  new Product
                  {
                      Id = 12,
                      Name = "Lavender Plant",
                      Description = "Fragrant lavender for gardens",
                      Price = 85.50m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 5
                  },
                  new Product
                  {
                      Id = 13,
                      Name = "Tomato Seedlings",
                      Description = "Early girl tomato plants",
                      Price = 15.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 6
                  },
                  new Product
                  {
                      Id = 14,
                      Name = "Cucumber Seedlings",
                      Description = "Burpless cucumber plants, disease-resistant",
                      Price = 13.25m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "642b8bd1-a65f-4598-95bc-29b833dcb84e",
                      CategoryId = 6
                  },
                  new Product
                  {
                      Id = 15,
                      Name = "Poultry Feed 20kg",
                      Description = "Organic chicken feed",
                      Price = 150.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "655501be-8ca7-434d-9cbe-6e8d23b3d92c",
                      CategoryId = 7
                  },
                  new Product
                  {
                      Id = 16,
                      Name = "Cattle Feed 25kg",
                      Description = "Nutritional cattle mix",
                      Price = 220.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "655501be-8ca7-434d-9cbe-6e8d23b3d92c",
                      CategoryId = 7
                  },
                  new Product
                  {
                      Id = 17,
                      Name = "Pruning Shears",
                      Description = "Professional grade shears",
                      Price = 65.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "655501be-8ca7-434d-9cbe-6e8d23b3d92c",
                      CategoryId = 8
                  },
                  new Product
                  {
                      Id = 18,
                      Name = "Garden Hoe",
                      Description = "Sturdy steel garden hoe",
                      Price = 45.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "655501be-8ca7-434d-9cbe-6e8d23b3d92c",
                      CategoryId = 8
                  },
                  new Product
                  {
                      Id = 19,
                      Name = "Compost 10kg",
                      Description = "Nutrient-rich compost",
                      Price = 40.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "655501be-8ca7-434d-9cbe-6e8d23b3d92c",
                      CategoryId = 10
                  },
                  new Product
                  {
                      Id = 20,
                      Name = "Worm Castings",
                      Description = "Organic soil amendment",
                      Price = 55.00m,
                      Availability = Availability.Sale,
                      CreatedAt = DateTime.UtcNow,
                      UpdatedAt = DateTime.UtcNow,
                      UserId = "655501be-8ca7-434d-9cbe-6e8d23b3d92c",
                      CategoryId = 10
                  }

              );
        }
    }
}