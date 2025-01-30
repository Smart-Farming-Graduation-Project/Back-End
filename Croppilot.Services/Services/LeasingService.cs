using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services
{
    public class LeasingService(IUnitOfWork unit) : ILeasingService
    {
        public async Task<Leasing> CreateLeasingAsync(Leasing leasing)
        {
            leasing.StartingDate = DateTime.UtcNow;
            return await unit.LeasingRepository.AddAsync(leasing); ;
        }

        public async Task<Leasing> UpdateLeasingAsync(int id, Leasing updatedLeasing)
        {
            var leasing = await unit.LeasingRepository.GetAsync(x => x.Id == id);
            if (leasing == null) return null;

            leasing.StartingDate = updatedLeasing.StartingDate;
            leasing.EndDate = updatedLeasing.EndDate;
            leasing.LeasingDetails = updatedLeasing.LeasingDetails;
            await unit.LeasingRepository.UpdateAsync(leasing);
            return leasing;
        }

        public async Task<Leasing?> GetLeasingByIdAsync(int id)
        {
            return await unit.LeasingRepository.GetAsync(x => x.Id == id, includeProperties: "Product");
        }

        public async Task<IEnumerable<Leasing>> GetAllLeasingsAsync()
        {
            return await unit.LeasingRepository.GetAllAsync(includeProperties: "Product");
        }

        public async Task<IEnumerable<Leasing>> GetLeasingsByProductIdAsync(int productId)
        {
            return await unit.LeasingRepository.GetAllAsync(x => x.ProductId == productId, includeProperties: "Product");
        }

        public async Task<bool> DeleteLeasingAsync(int id)
        {
            var leasing = await unit.LeasingRepository.GetAsync(x => x.Id == id);
            if (leasing == null) return false;
            await unit.LeasingRepository.DeleteAsync(leasing);
            return true;
        }
    }
}
