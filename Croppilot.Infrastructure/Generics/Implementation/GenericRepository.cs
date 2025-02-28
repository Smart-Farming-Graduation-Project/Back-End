namespace Croppilot.Infrastructure.Generics.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private bool _disposed;
	protected readonly AppDbContext _context;
	private readonly DbSet<T> _dbSet;

	public GenericRepository(AppDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}

	public async Task<List<T>> GetAllAsync(
		Expression<Func<T, bool>>? filter = null,
		string[]? includeProperties = null,
		bool tracked = false,
		CancellationToken cancellationToken = default)
	{
		var query = tracked ? _dbSet : _dbSet.AsNoTracking();

		if (filter != null)
			query = query.Where(filter);

		if (includeProperties == null || includeProperties.Length == 0)
			return await query.ToListAsync(cancellationToken);

		foreach (var property in includeProperties)
			query = query.Include(property.Trim());

		return await query.ToListAsync(cancellationToken);
	}

	public async Task<T?> GetAsync(
		Expression<Func<T, bool>>? filter = null,
		string[]? includeProperties = null,
		bool tracked = false,
		CancellationToken cancellationToken = default)
	{
		var query = tracked ? _dbSet : _dbSet.AsNoTracking();

		if (filter != null)
			query = query.Where(filter);

		if (includeProperties == null || includeProperties.Length == 0)
			return await query.FirstOrDefaultAsync(cancellationToken);

		foreach (var property in includeProperties)
			query = query.Include(property.Trim());

		return await query.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<IQueryable<T>> GetForPaginationAsync(
		Expression<Func<T, bool>>? filter = null,
		string[]? includeProperties = null,
		bool tracked = false)
	{
		var query = tracked ? _dbSet : _dbSet.AsNoTracking();

		if (filter != null)
			query = query.Where(filter);

		if (includeProperties == null || includeProperties.Length == 0)
			return query;

		foreach (var property in includeProperties)
			query = query.Include(property.Trim());

		return query;
	}

	public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
	{
		if (entity == null)
			throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

		try
		{
			await _dbSet.AddAsync(entity, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}
		catch (DbUpdateException ex)
		{
			throw new InvalidOperationException("An error occurred while saving the entity to the database.", ex);
		}

		return entity;
	}

	public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		if (entities == null)
			throw new ArgumentNullException(nameof(entities), "Entities collection cannot be null.");

		try
		{
			await _dbSet.AddRangeAsync(entities, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}
		catch (DbUpdateException ex)
		{
			throw new InvalidOperationException("An error occurred while saving the entities to the database.", ex);
		}
	}

	public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
	{
		if (entity == null)
			throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

		try
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);
		}
		catch (DbUpdateException ex)
		{
			throw new InvalidOperationException("An error occurred while updating the entity in the database.", ex);
		}
	}

	public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
	{
		if (entity == null)
			throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

		try
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);
		}
		catch (DbUpdateException ex)
		{
			throw new InvalidOperationException("An error occurred while deleting the entity from the database.", ex);
		}
	}

	public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		if (entities == null)
			throw new ArgumentNullException(nameof(entities), "Entities collection cannot be null.");

		try
		{
			_dbSet.RemoveRange(entities);
			await _context.SaveChangesAsync(cancellationToken);
		}
		catch (DbUpdateException ex)
		{
			throw new InvalidOperationException("An error occurred while deleting the entities from the database.", ex);
		}
	}

	public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
	{
		return await _dbSet.AnyAsync(filter, cancellationToken);
	}

	public Task<IDbContextTransaction> BeginTransactionAsync()
	{
		return _context.Database.BeginTransactionAsync();
	}

	public Task CommitTransactionAsync()
	{
		return _context.Database.CommitTransactionAsync();
	}

	public Task RollbackTransactionAsync()
	{
		return _context.Database.RollbackTransactionAsync();
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (_disposed)
			return;

		if (disposing)
			_context.Dispose();

		_disposed = true;
	}
}