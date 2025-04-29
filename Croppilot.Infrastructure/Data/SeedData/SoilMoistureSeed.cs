using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class SoilMoistureSeed
    {
        public static void SeedSoilMoisture(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoilMoisture>().HasData(
                new SoilMoisture { Id = 1, FieldName = "Field Alpha", Moisture = 58, Optimal = 65, PH = 6.2f, FieldId = 1 },
                new SoilMoisture { Id = 2, FieldName = "Field Beta", Moisture = 62, Optimal = 60, PH = 6.5f, FieldId = 2 },
                new SoilMoisture { Id = 3, FieldName = "Field Gamma", Moisture = 70, Optimal = 68, PH = 6.8f, FieldId = 3 },
                new SoilMoisture { Id = 4, FieldName = "Field Delta", Moisture = 45, Optimal = 60, PH = 5.9f, FieldId = 4 },
                new SoilMoisture { Id = 5, FieldName = "Field Epsilon", Moisture = 67, Optimal = 70, PH = 6.3f, FieldId = 5 },
                new SoilMoisture { Id = 6, FieldName = "Field Zeta", Moisture = 52, Optimal = 60, PH = 6.0f, FieldId = 6 }
            );
        }
    }
}
