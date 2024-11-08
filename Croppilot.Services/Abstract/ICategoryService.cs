using Croppilot.Date.Enum;

namespace Croppilot.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync(string? includeProperties = null, CancellationToken cancellationToken = default);
        Task<Category?> GetByIdAsync(int id, string? includeProperties = null, CancellationToken cancellationToken = default);
        Task<string> CreateAsync(Category category, CancellationToken cancellationToken = default);
        Task<string> UpdateAsync(Category category, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Category?> GetByNameAsync(string name);
        Task<IQueryable<Category>> FilterCategoryQueryable(CategoryOrderingEnum ordering, string? search);

    }
}