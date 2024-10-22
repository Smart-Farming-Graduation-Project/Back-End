namespace Croppilot.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

    }
}
