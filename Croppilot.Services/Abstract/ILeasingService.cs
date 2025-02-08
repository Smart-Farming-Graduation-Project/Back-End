using Croppilot.Date.Enum;

namespace Croppilot.Services.Abstract
{
    public interface ILeasingService
    {

        //  Task<Leasing> CreateLeasingAsync(Leasing leasing);
        Task<Leasing> UpdateLeasingAsync(int id, Leasing updatedLeasing);
        Task<Leasing?> GetLeasingByIdAsync(int id);
        Task<IEnumerable<Leasing>> GetAllLeasingsAsync();
        Task<IEnumerable<Leasing>> GetLeasingsByProductIdAsync(int productId);
        Task<OperationResult> DeleteLeasingAsync(int id);

        Task<OperationResult> LeaseProductAsync(int productId, DateTime startDate, string leasingDetails);
        Task<OperationResult> EndLeaseAsync(int leasingId);
        Task<IEnumerable<Leasing>> GetActiveLeasesAsync();
    }
}
