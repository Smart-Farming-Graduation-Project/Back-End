namespace Croppilot.Services.Abstract
{
    public interface IProductImageServices
    {
        Task<List<ProductImage>> GetByProductIdAsync(int productId, CancellationToken cancellationToken = default);
    }
}
