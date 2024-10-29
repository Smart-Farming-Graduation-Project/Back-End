using Croppilot.Infrastructure.Generics.Interfaces;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}