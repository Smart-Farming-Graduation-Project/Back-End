using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Services.Abstract.DashboredServices
{
    public interface IFieldService
    {
        Task<IEnumerable<Field>> GetAllAsync();
        Task<Field> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(Field field);
        Task<bool> UpdateAsync(Field field);
        Task<bool> DeleteAsync(int id);
        Task<IrrigationType?> GetMostUsedIrrigationTypeAsync();
    }
}
