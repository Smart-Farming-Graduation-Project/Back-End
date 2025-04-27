namespace Croppilot.Services.Abstract
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAllAsync(string[]? includeProperties = null,
			CancellationToken cancellationToken = default);

		Task<Category?> GetByIdAsync(int id, string[]? includeProperties = null,
			CancellationToken cancellationToken = default);

		Task<OperationResult> CreateAsync(Category category, CancellationToken cancellationToken = default);
		Task<OperationResult> UpdateAsync(Category category, CancellationToken cancellationToken = default);
		Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
		Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
		Task<IQueryable<Category>> FilterCategoryQueryable(CategoryOrderingEnum ordering, string? search);
		Task UploadImageAndUpdateCategory(int categoryId, byte[] image, string extension);
		Task ChangeCategoryImageAndUpdateCategory(int categoryId, byte[] image, string extension);
	}
}