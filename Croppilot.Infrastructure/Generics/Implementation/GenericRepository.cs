using Croppilot.Infrastructure.Generics.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Croppilot.Infrastructure.Generics.Implementation
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private bool disposed = false;
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        //public virtual async Task<List<T>> GetAll()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        //public virtual async Task<T?> GetByIdAsync(int id)
        //{
        //    return await _dbSet.FindAsync(id);

        //}
        //public virtual async Task<List<T>> GetAllAsNoTrackingAsync()
        //{
        //    return await _dbSet.AsNoTracking().ToListAsync();
        //}


        //public async Task<List<T>> GetAllAsTrackingAsync()
        //{
        //    return await _dbSet.ToListAsync();
        //}

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperty = null, bool tracked = false)
        {
            IQueryable<T> query = tracked ? _dbSet : _dbSet.AsNoTracking();

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var item in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item.Trim());
                }
            }

            return await query.ToListAsync();
        }



        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperty = null, bool tracked = false)
        {
            IQueryable<T> query;
            query = tracked ? _dbSet : _dbSet.AsNoTracking();
            if (filter is not null)
                query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var item in includeProperty.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item.Trim());
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }


        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }




        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool dispossing)
        {
            if (!this.disposed)
                if (dispossing)
                    _context.Dispose();
            this.disposed = true;
        }
    }
}
