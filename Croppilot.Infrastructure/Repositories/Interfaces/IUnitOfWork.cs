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
        ICartRepository CartRepository { get; }
        IWishlistRepository WishlistRepository { get; }
    }
}