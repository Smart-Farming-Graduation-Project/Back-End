using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Services.Services.DashboredServices
{
    public class FieldService(IFieldRepository fieldRepository) : IFieldService
    {
        public async Task<OperationResult> CreateAsync(Field field)
        {
            await fieldRepository.AddAsync(field);
            return OperationResult.Success;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingField = await fieldRepository.GetAsync(x => x.Id == id);
            if (existingField == null)
            {
                return false;
            }
            await fieldRepository.DeleteAsync(existingField);
            return true;
        }

        public async Task<IrrigationType?> GetMostUsedIrrigationTypeAsync()
        {

            var fields = await fieldRepository.GetAllAsync();

            return fields
                .GroupBy(f => f.Irrigation)
                .OrderByDescending(g => g.Count())
                .Select(g => (IrrigationType?)g.Key)
                .FirstOrDefault();

        }

        public async Task<IEnumerable<Field>> GetAllAsync()
        {
            return await fieldRepository.GetAllAsync();
        }

        public async Task<Field> GetByIdAsync(int id)
        {
            return await fieldRepository.GetAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Field field)
        {
            var existingField = await fieldRepository.GetAsync(x => x.Id == field.Id);
            if (existingField == null)
            {
                return false;
            }
            existingField.Name = field.Name;
            existingField.Size = field.Size;
            existingField.Crop = field.Crop;
            existingField.PlantingDate = field.PlantingDate;
            existingField.HarvestDate = field.HarvestDate;
            existingField.Irrigation = field.Irrigation;
            existingField.Status = field.Status;
            await fieldRepository.UpdateAsync(existingField);
            return true;
        }
    }
}
