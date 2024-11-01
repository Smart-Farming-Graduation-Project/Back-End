using Croppilot.Date.DTOS;
using Croppilot.Date.Enum;

namespace Croppilot.Services.Abstract
{
    public interface IProductServices
    {
        Task<IQueryable<Product>> GetAll(string? includeProperties = null, CancellationToken cancellationToken = default);
        Task<Product?> GetById(int id, string? includeProperties = null, CancellationToken cancellationToken = default);
        Task CreateAsync(CreateProductDTO product, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, UpdateProductDTO product, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        IEnumerable<Product> GetByDate(int nights, DateOnly checkInDate);
        bool IsAvailableForLeasing(int productId);
        Task<IQueryable<Product>> FilterProductQueryable(ProductOrderingEnum ordering, string? search);
    }
}