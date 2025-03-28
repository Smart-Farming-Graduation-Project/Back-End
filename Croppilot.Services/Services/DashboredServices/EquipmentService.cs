using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Services.Services.DashboredServices
{
    public class EquipmentService(IEquipmentRepository equipmentRepository) : IEquipmentService
    {
        public async Task<Equipment> CreateAsync(Equipment equipment)
        {
            await equipmentRepository.AddAsync(equipment);
            return equipment;
        }

        public async Task<bool> DeleteAsync(string equipmentId)
        {
            var equipment = await GetByIdAsync(equipmentId);
            if (equipment == null) return false;

            await equipmentRepository.DeleteAsync(equipment);
            return true;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await equipmentRepository.GetAllAsync();
        }

        public async Task<Equipment> GetByIdAsync(string equipmentId)
        {
            return await equipmentRepository.GetAsync(x => x.EquipmentId == equipmentId);
        }

        public async Task<bool> UpdateAsync(Equipment equipment)
        {
            var existingEquipment = await GetByIdAsync(equipment.EquipmentId);
            if (existingEquipment == null) return false;
            existingEquipment.Name = equipment.Name;
            existingEquipment.Status = equipment.Status;
            existingEquipment.LastMaintenance = DateTime.UtcNow;
            existingEquipment.HoursUsed = equipment.HoursUsed;
            existingEquipment.Battery = equipment.Battery;
            existingEquipment.Connectivity = equipment.Connectivity;
            await equipmentRepository.UpdateAsync(existingEquipment);
            return true;
        }
    }
}
