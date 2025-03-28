using Croppilot.Date.Enum;
using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Data.Extensions
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
                    CategoryId = 20
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
                    CategoryId = 21
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
                    CategoryId = 22
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
                    CategoryId = 20
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
                    CategoryId = 21
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
            // Seed Initial Equipment Data
            modelBuilder.Entity<Equipment>().HasData(
               new Equipment { Id = 1, EquipmentId = "EQ-001", Name = "Tractor A", Status = EquipmentStatus.Active, LastMaintenance = DateTime.UtcNow.AddDays(-30), HoursUsed = 120, Battery = 85, Connectivity = EquipmentConnectivity.Online },
               new Equipment { Id = 2, EquipmentId = "EQ-002", Name = "Drone B", Status = EquipmentStatus.Idle, LastMaintenance = DateTime.UtcNow.AddDays(-15), HoursUsed = 50, Battery = 60, Connectivity = EquipmentConnectivity.Offline },
               new Equipment { Id = 3, EquipmentId = "EQ-003", Name = "Sprinkler C", Status = EquipmentStatus.Maintenance, LastMaintenance = DateTime.UtcNow.AddDays(-10), HoursUsed = 30, Battery = 95, Connectivity = EquipmentConnectivity.Online },
               new Equipment { Id = 4, EquipmentId = "EQ-004", Name = "Harvester D", Status = EquipmentStatus.Active, LastMaintenance = DateTime.UtcNow.AddDays(-45), HoursUsed = 200, Battery = 75, Connectivity = EquipmentConnectivity.Online },
               new Equipment { Id = 5, EquipmentId = "EQ-005", Name = "Seeder E", Status = EquipmentStatus.Idle, LastMaintenance = DateTime.UtcNow.AddDays(-5), HoursUsed = 20, Battery = 100, Connectivity = EquipmentConnectivity.Offline },
               new Equipment { Id = 6, EquipmentId = "EQ-006", Name = "Plow F", Status = EquipmentStatus.Maintenance, LastMaintenance = DateTime.UtcNow.AddDays(-20), HoursUsed = 90, Battery = 50, Connectivity = EquipmentConnectivity.Online }
             );

            // Seed Initial Field Data
            modelBuilder.Entity<Field>().HasData(
              new Field { Id = 1, Name = "Field Alpha", Size = 10.5, Crop = "Wheat", PlantingDate = DateTime.UtcNow.AddMonths(-3), HarvestDate = DateTime.UtcNow.AddMonths(2), Irrigation = IrrigationType.Drip, Status = FieldStatus.Planted },
              new Field { Id = 2, Name = "Field Beta", Size = 15.2, Crop = "Corn", PlantingDate = DateTime.UtcNow.AddMonths(-2), HarvestDate = DateTime.UtcNow.AddMonths(3), Irrigation = IrrigationType.Sprinkler, Status = FieldStatus.Planted },
              new Field { Id = 3, Name = "Field Gamma", Size = 8.0, Crop = "Rice", PlantingDate = DateTime.UtcNow.AddMonths(-4), HarvestDate = DateTime.UtcNow.AddMonths(1), Irrigation = IrrigationType.Flood, Status = FieldStatus.Planted },
              new Field { Id = 4, Name = "Field Delta", Size = 12.7, Crop = "Soybeans", PlantingDate = DateTime.UtcNow.AddMonths(-1), HarvestDate = DateTime.UtcNow.AddMonths(5), Irrigation = IrrigationType.Drip, Status = FieldStatus.Preparing },
              new Field { Id = 5, Name = "Field Epsilon", Size = 20.3, Crop = "Barley", PlantingDate = DateTime.UtcNow.AddMonths(-5), HarvestDate = DateTime.UtcNow.AddMonths(3), Irrigation = IrrigationType.CenterPivot, Status = FieldStatus.Planted },
              new Field { Id = 6, Name = "Field Zeta", Size = 9.5, Crop = "Oats", PlantingDate = DateTime.UtcNow.AddMonths(-6), HarvestDate = DateTime.UtcNow.AddMonths(4), Irrigation = IrrigationType.Manual, Status = FieldStatus.Fallow }
            );
        }
    }
}
