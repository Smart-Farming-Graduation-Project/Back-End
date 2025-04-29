using Croppilot.Infrastructure.Data.SeedData;

namespace Croppilot.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
            modelBuilder.SeedProductImages();
            modelBuilder.SeedEquipments();
            modelBuilder.SeedFields();
            modelBuilder.SeedSoilMoisture();
            modelBuilder.SeedAlerts();
        }
    }
}
