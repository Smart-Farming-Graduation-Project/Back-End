using Microsoft.EntityFrameworkCore.Storage;

namespace Croppilot.Infrastructure.Generics.Interfaces
{
    internal interface IGenericRepository<T> where T : class
    {
        //  Task<List<T>> GetAll();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);

        IQueryable<T> GetAllAsNoTracking();
        IQueryable<T> GetAllAsTracking();


        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
