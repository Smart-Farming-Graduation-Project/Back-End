using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Services.Services.DashboredServices
{
    public class EquipmentService(IEquipmentRepository equipmentRepository) : IEquipmentService
    {
        public async Task<OperationResult> CreateAsync(Equipment equipment)
        {
            await equipmentRepository.AddAsync(equipment);
            return OperationResult.Success;
        }

        public async Task<bool> DeleteAsync(string equipmentId)
        {
            var equipment = await GetByIdAsync(equipmentId);
            if (equipment == null) return false;

            await equipmentRepository.DeleteAsync(equipment);
            return true;
        }

        public async Task<bool> UpdateEquipmentStatus(string id, string status)
        {
            var result = await equipmentRepository.UpdateStatus(id, status);
            if (result is true)
                return true;
            return false;
        }

        public async Task<int> GetActiveEquipmentCount()
        {
            var equipmentList = await equipmentRepository.GetAllAsync(x => x.Status == EquipmentStatus.Active);

            if (equipmentList == null) return 0;
            return equipmentList.Count();
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
