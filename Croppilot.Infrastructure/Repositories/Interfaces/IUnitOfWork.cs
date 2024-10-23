using Croppilot.Infrastructure.Generics.Interfaces;

namespace Croppilot.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;

        IProductRepository ProductRepository { get; }

    }
}
