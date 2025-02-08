namespace Croppilot.Services.Abstract
{
    public interface ILeasingService
    {

        //  Task<Leasing> CreateLeasingAsync(Leasing leasing);
        Task<Leasing> UpdateLeasingAsync(int id, Leasing updatedLeasing);
        Task<Leasing?> GetLeasingByIdAsync(int id);
        Task<IEnumerable<Leasing>> GetAllLeasingsAsync();
        Task<IEnumerable<Leasing>> GetLeasingsByProductIdAsync(int productId);
        Task<bool> DeleteLeasingAsync(int id);

        Task<Leasing> LeaseProductAsync(int productId, DateTime startDate, string leasingDetails);
        Task<bool> EndLeaseAsync(int leasingId);
        Task<IEnumerable<Leasing>> GetActiveLeasesAsync();
    }
}
