namespace Croppilot.Infrastructure.Generics.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false,CancellationToken cancellationToken = default);
        Task<T?> GetAsync(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false,CancellationToken cancellationToken = default);

        Task<T> AddAsync(T entity,CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
