using Croppilot.Infrastructure.Generics.Implementation;
using Croppilot.Infrastructure.Generics.Interfaces;

namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }
        public ILeasingRepository LeasingRepository { get; }


        private readonly AppDbContext _context;
        private bool _disposed;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            ProductImageRepository = new ProductImageRepository(_context);
            LeasingRepository = new LeasingRepository(_context);
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