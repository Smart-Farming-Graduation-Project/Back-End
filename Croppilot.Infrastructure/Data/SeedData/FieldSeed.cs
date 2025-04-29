using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class FieldSeed
    {
        public static void SeedFields(this ModelBuilder modelBuilder)
        {
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
