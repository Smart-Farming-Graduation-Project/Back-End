using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Repositories.Interfaces.Dashbored
{
    public interface ISoilRepository : IGenericRepository<SoilMoisture>
    {
        Task<IEnumerable<SoilMoisture>?> SoilMoistureReadings();
    }
}
