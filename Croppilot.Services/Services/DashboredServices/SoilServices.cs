using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Services.Services.DashboredServices
{
    public class SoilServices(ISoilRepository soilRepository) : ISoilServices
    {
        public async Task<IEnumerable<SoilMoisture>?> GetAll()
        {
            var soilMoisture = await soilRepository.SoilMoistureReadings();
            if (soilMoisture == null || !soilMoisture.Any())
            {
                return null;
            }
            return soilMoisture;

        }
    }
}
