using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

namespace Croppilot.Infrastructure.Repositories.Implementation.Dashbored
{
    public class AlertsRepository(AppDbContext context) : GenericRepository<Alert>(context), IAlertsRepository
    {
    }
}
