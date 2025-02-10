using Croppilot.Date.Enum;

namespace Croppilot.Services.Abstract
{
    public interface IProductServices
    {
        Task<IQueryable<Product>> GetAll(string[]? includeProperties = null,
            CancellationToken cancellationToken = default);

        Task<Product?> GetByIdAsync(int id, string[]? includeProperties = null,
            CancellationToken cancellationToken = default);

        Task<OperationResult> CreateAsync(Product product, List<string> iamgeList,
            CancellationToken cancellationToken = default);

        Task<OperationResult> UpdateAsync(Product product, List<string> imageList,
            CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        IEnumerable<Product> GetByDate(int nights, DateOnly checkInDate);
        bool IsAvailableForLeasing(int productId);
        Task<IQueryable<Product>> FilterProductQueryable(ProductOrderingEnum ordering, string? search);
    }
}