using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

namespace Croppilot.Infrastructure.Repositories.Implementation.Dashbored
{
    public class EquipmentRepository(AppDbContext context) : GenericRepository<Equipment>(context), IEquipmentRepository
    {
    }
}
