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

        public async Task<Leasing?> GetLeasingsByProductIdAsync(int productId)
        {
            return await unit.LeasingRepository.GetAsync(x => x.ProductId == productId,
                includeProperties: ["Product"]);
        }

        public async Task<OperationResult> DeleteLeasingAsync(int id)
        {
            var leasing = await unit.LeasingRepository.GetAsync(x => x.Id == id);
            if (leasing == null) return OperationResult.NotFound;
            await unit.LeasingRepository.DeleteAsync(leasing);
            return OperationResult.Success;
        }



        public async Task<OperationResult> LeaseProductAsync(int productId, DateTime startDate, DateTime endDate, string leasingDetails)
        {

            var product = await unit.ProductRepository.GetAsync(x => x.Id == productId);
            if (product is null)
                return OperationResult.NotFound;

            // Ensure the product is available for leasing
            if (product.Availability != Availability.Lease)
                return OperationResult.NotAvailable;

            // Ensure EndDate is after StartDate
            if (endDate <= startDate)
                return OperationResult.InvalidDate;

            // Check if an active lease exists (product is already leased)
            var activeLease = await unit.LeasingRepository.GetAsync(x =>
                x.ProductId == productId && x.EndDate >= DateTime.UtcNow
            );

            if (activeLease is not null)
                return OperationResult.AlreadyLeased;

            var lease = new Leasing
            {
                ProductId = productId,
                StartingDate = startDate,
                EndDate = endDate,
                LeasingDetails = leasingDetails
            };

            await unit.LeasingRepository.AddAsync(lease);
            return OperationResult.Success;
        }


        public async Task<OperationResult> EndLeaseAsync(int leasingId)
        {
            var lease = await unit.LeasingRepository.GetAsync(x => x.Id == leasingId);
            if (lease == null)
                return OperationResult.NotFound;

            if (lease.EndDate.HasValue)
                return OperationResult.AlreadyEnded;

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