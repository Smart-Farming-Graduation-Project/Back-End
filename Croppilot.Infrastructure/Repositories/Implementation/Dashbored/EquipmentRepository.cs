using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

namespace Croppilot.Infrastructure.Repositories.Implementation.Dashbored
{
    public class EquipmentRepository(AppDbContext context) : GenericRepository<Equipment>(context), IEquipmentRepository
    {
        public async Task<bool> UpdateStatus(string id, string status)
        {
            var equipment = await context.Equipments.FirstOrDefaultAsync(x => x.EquipmentId == id);
            if (equipment != null)
            {
                if (Enum.TryParse(status, out EquipmentStatus equipmentStatus))
                {
                    equipment.Status = equipmentStatus;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
