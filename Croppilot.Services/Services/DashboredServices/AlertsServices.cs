using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Services.Services.DashboredServices
{
    public class AlertsServices(IAlertsRepository alertsRepository) : IAlertsServices
    {
        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            return await alertsRepository.GetAllAsync();
        }

        public async Task<OperationResult> CreateAsync(Alert alert)
        {
            var result = await alertsRepository.AddAsync(alert);
            return OperationResult.Success;
        }
    }
}
