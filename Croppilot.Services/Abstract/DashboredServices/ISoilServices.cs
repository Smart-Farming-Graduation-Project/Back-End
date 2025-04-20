using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Services.Abstract.DashboredServices
{
    public interface ISoilServices
    {
        Task<IEnumerable<SoilMoisture>?> GetAll();
    }
}
