using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Services.Abstract.DashboredServices
{
    public interface IAlertsServices
    {
        Task<IEnumerable<Alert>> GetAllAsync();
        Task<OperationResult> CreateAsync(Alert alert);
    }
}
