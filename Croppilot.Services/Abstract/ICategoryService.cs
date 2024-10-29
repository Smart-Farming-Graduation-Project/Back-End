namespace Croppilot.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync(string? includeProperties = null, CancellationToken cancellationToken = default);
        Task<Category?> GetByIdAsync(int id, string? includeProperties = null, CancellationToken cancellationToken = default);
        Task CreateAsync(Category category, CancellationToken cancellationToken = default);
        Task UpdateAsync(Category category, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}