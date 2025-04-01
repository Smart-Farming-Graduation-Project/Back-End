using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Repositories.Interfaces.Dashbored
{
    public interface IEquipmentRepository : IGenericRepository<Equipment>
    {
        Task<bool> UpdateStatus(string id, string status);
    }
}
