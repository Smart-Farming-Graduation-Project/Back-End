using Croppilot.Date.Models;

namespace Croppilot.Services.Abstract
{
    public interface IProductServices
    {
        Task<List<Product>> GetAllProduct(string? includeProp = null);
        Task<Product> GetProductById(int id, string? includeProp = null);
        Task CreateAsync(Product villa);
        Task UpdateAsync(Product villa);
        Task<bool> Delete(int id);
        IEnumerable<Product> GetProductByDate(int nights, DateOnly checkInDate);
        bool IsProductAvailableForLeasing(int villaId);
    }
}
