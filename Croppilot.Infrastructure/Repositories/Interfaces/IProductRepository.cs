using Croppilot.Infrastructure.Generics.Interfaces;

namespace Croppilot.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductsById(int id);
    }
}
