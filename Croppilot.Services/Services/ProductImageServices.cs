using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services
{
    public class ProductImageServices(IUnitOfWork unit) : IProductImageServices
    {
        public async Task<List<ProductImage>> GetByProductIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            var productImages = await unit.ProductImageRepository.GetAllAsync(x => x.ProductId == productId, tracked: false, cancellationToken: cancellationToken);
            return productImages;
        }
    }
}
