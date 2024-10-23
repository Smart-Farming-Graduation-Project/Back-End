using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Croppilot.Infrastructure.Generics.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperty = null, bool tracked = false);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperty = null, bool tracked = false);

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);

        //Task<List<T>> GetAllAsNoTracking();
        //Task<List<T>> GetAllAsTrackingAsync();
        //Task<T?> GetByIdAsync(int id);
        //  Task<List<T>> GetAll();

        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    }
}
