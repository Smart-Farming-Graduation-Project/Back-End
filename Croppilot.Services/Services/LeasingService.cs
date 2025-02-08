using Croppilot.Date.Enum;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services
{
    public class LeasingService(IUnitOfWork unit) : ILeasingService
    {
        //public async Task<Leasing> CreateLeasingAsync(Leasing leasing)
        //{
        //    leasing.StartingDate = DateTime.UtcNow;
        //    return await unit.LeasingRepository.AddAsync(leasing);
        //    ;
        //}

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
            return await unit.LeasingRepository.GetAsync(x => x.Id == id, includeProperties: ["Product"]);
        }


        public async Task<IEnumerable<Leasing>> GetAllLeasingsAsync()
        {
            return await unit.LeasingRepository.GetAllAsync(includeProperties: ["Product"]);
        }

        public async Task<IEnumerable<Leasing>> GetLeasingsByProductIdAsync(int productId)
        {
            return await unit.LeasingRepository.GetAllAsync(x => x.ProductId == productId,
                includeProperties: ["Product"]);
        }

        public async Task<OperationResult> DeleteLeasingAsync(int id)
        {
            var leasing = await unit.LeasingRepository.GetAsync(x => x.Id == id);
            if (leasing == null) return OperationResult.NotFound;
            await unit.LeasingRepository.DeleteAsync(leasing);
            return OperationResult.Success;
        }

        public async Task<OperationResult> LeaseProductAsync(int productId, DateTime startDate, string leasingDetails)
        {
            var product = unit.ProductRepository.GetAsync(x => x.Id == productId);
            if (product == null) return OperationResult.NotFound;
            ;
            if (product.Result!.Availability != Availability.Lease)
                throw new Exception("This product is not available for leasing.");
            var lease = new Leasing
            {
                ProductId = productId,
                StartingDate = startDate,
                LeasingDetails = leasingDetails
            };
            var addedLease = await unit.LeasingRepository.AddAsync(lease);
            return OperationResult.Success;
        }

        public async Task<OperationResult> EndLeaseAsync(int leasingId)
        {
            var lease = await unit.LeasingRepository.GetAsync(x => x.Id == leasingId);
            if (lease == null)
                return OperationResult.NotFound; // Lease not found

            if (lease.EndDate.HasValue)
                throw new Exception("Lease is already ended.");

            lease.EndDate = DateTime.UtcNow;
            await unit.LeasingRepository.UpdateAsync(lease);
            return OperationResult.Success;
        }

        public async Task<IEnumerable<Leasing>> GetActiveLeasesAsync()
        {
            return await unit.LeasingRepository.GetAllAsync(x => !x.EndDate.HasValue, includeProperties: ["Product"]);
        }
    }
}