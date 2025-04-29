using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class CategorySeed
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruits", Description = "All types of fruits" },
                new Category { Id = 2, Name = "Vegetables", Description = "All types of vegetables" },
                new Category { Id = 3, Name = "Grains", Description = "All types of grains" },
                new Category { Id = 4, Name = "Dairy", Description = "All types of dairy products" },
                new Category { Id = 5, Name = "Meat", Description = "All types of meat products" }
            );
        }
    }
}
