using Croppilot.Infrastructure.Repositories.Interfaces.AiRepository;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

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
        IReviewRepository ReviewRepository { get; }
        IChatRepository ChatRepository { get; }
        IPostRepository PostRepository { get; }
        ICommentRepository CommentRepository { get; }
        IVoteRepository VoteRepository { get; }

        //Ai Repositories
        IFeedbackRepository FeedbackRepository { get; }
        IModelRepository ModelRepository { get; }

        //Dashbord Repositories
        IWeatherDataRepository WeatherDataRepository { get; }
        IWeatherForcastRepository WeatherForecastRepository { get; }

    }
}