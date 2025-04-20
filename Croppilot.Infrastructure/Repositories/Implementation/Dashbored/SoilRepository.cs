using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

namespace Croppilot.Infrastructure.Repositories.Implementation.Dashbored
{
    public class SoilRepository(AppDbContext context) : GenericRepository<SoilMoisture>(context), ISoilRepository
    {
        public async Task<IEnumerable<SoilMoisture>?> SoilMoistureReadings()
        {

            var soilMoisture = await context.SoilMoistures
                .Include(sm => sm.Field)
                .Where(sm => sm.Field != null)
                .Select(sm => new SoilMoisture()
                {
                    Id = sm.Id,
                    FieldName = sm.Field.Name,
                    Moisture = sm.Moisture,
                    Optimal = sm.Optimal,
                    PH = sm.PH,
                    //Field = new FieldDTO
                    //{
                    //    Id = sm.Field.Id,
                    //    Name = sm.Field.Name
                    //}
                })
                .ToListAsync();
            if (soilMoisture == null || !soilMoisture.Any())
            {
                return null;
            }

            return soilMoisture;
        }
    }
}
