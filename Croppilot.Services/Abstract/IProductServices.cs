using Croppilot.Date.DTOS;

namespace Croppilot.Services.Abstract
{
    public interface IProductServices
    {
        Task<List<ProductDTO>> GetAll(string? includeProperties = null, CancellationToken cancellationToken = default);
        Task<Product?> GetById(int id, string? includeProperties = null, CancellationToken cancellationToken = default);
        Task CreateAsync(Product product, CancellationToken cancellationToken = default);
        Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        IEnumerable<Product> GetByDate(int nights, DateOnly checkInDate);
        bool IsAvailableForLeasing(int productId);
    }
}