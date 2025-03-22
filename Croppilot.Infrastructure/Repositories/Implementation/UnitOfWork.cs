using Croppilot.Infrastructure.Repositories.Implementation.AiRepository;
using Croppilot.Infrastructure.Repositories.Interfaces.AiRepository;

namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }
        public ILeasingRepository LeasingRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICartRepository CartRepository { get; }
        public IWishlistRepository WishlistRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IChatRepository ChatRepository { get; }
        public IPostRepository PostRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IVoteRepository VoteRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public IModelRepository ModelRepository { get; }


        private readonly AppDbContext _context;
        private bool _disposed;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            ProductImageRepository = new ProductImageRepository(_context);
            LeasingRepository = new LeasingRepository(_context);
            RefreshTokenRepository = new RefreshTokenRepository(_context);
            OrderRepository = new OrderRepository(_context);
            CartRepository = new CartRepository(_context);
            WishlistRepository = new WishlistRepository(_context);
            ReviewRepository = new ReviewRepository(_context);
            ChatRepository = new ChatRepository(_context);
            PostRepository = new PostRepository(_context);
            CommentRepository = new CommentRepository(_context);
            VoteRepository = new VoteRepository(_context);
            FeedbackRepository = new FeedbackRepository(_context);
            ModelRepository = new ModelRepository(_context);
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}