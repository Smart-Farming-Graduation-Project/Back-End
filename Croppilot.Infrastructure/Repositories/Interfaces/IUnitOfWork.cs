namespace Croppilot.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        ILeasingRepository LeasingRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        ICartRepository CartRepository { get; }
    }
}