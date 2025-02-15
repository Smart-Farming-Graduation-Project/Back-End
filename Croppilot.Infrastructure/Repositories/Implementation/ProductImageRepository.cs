namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class ProductImageRepository(AppDbContext context)
        : GenericRepository<ProductImage>(context), IProductImageRepository
    {
    }
}
