namespace Croppilot.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductsById(int id);
        void Detach(Product product);
    }
}
