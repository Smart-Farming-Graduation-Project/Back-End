using Microsoft.EntityFrameworkCore.Storage;

namespace Croppilot.Infrastructure.Generics.Interfaces
{
    internal interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<bool> Add(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);

        IQueryable<T> GetAllAsNoTracking();
        IQueryable<T> GetAllAsTracking();


        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
