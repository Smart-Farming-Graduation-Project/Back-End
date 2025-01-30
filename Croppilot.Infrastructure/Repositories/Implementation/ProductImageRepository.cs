using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class ProductImageRepository(AppDbContext context)
        : GenericRepository<ProductImage>(context), IProductImageRepository
    {
    }
}
