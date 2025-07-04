﻿using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Services.Abstract.DashboredServices
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(string equipmentId);
        Task<OperationResult> CreateAsync(Equipment equipment);
        Task<bool> UpdateAsync(Equipment equipment);
        Task<bool> DeleteAsync(string equipmentId);
        Task<bool> UpdateEquipmentStatus(string id, string status);
        Task<int> GetActiveEquipmentCount();
    }
}
