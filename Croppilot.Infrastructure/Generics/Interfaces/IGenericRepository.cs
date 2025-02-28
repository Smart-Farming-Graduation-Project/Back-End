namespace Croppilot.Infrastructure.Generics.Interfaces;

public interface IGenericRepository<T> : IDisposable where T : class
{
	Task<List<T>> GetAllAsync(
		Expression<Func<T, bool>>? filter = null,
		string[]? includeProperties = null,
		bool tracked = false,
		CancellationToken cancellationToken = default);

	Task<T?> GetAsync(
		Expression<Func<T, bool>>? filter = null,
		string[]? includeProperties = null,
		bool tracked = false,
		CancellationToken cancellationToken = default);

	Task<IQueryable<T>> GetForPaginationAsync(
		Expression<Func<T, bool>>? filter = null,
		string[]? includeProperties = null,
		bool tracked = false);


	Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

	Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

	Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

	Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

	Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<IDbContextTransaction> BeginTransactionAsync();

	Task CommitTransactionAsync();

	Task RollbackTransactionAsync();
}