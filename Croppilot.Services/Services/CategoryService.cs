using Croppilot.Date.Enum;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    public async Task<List<Category>> GetAllAsync(string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        return await unitOfWork.CategoryRepository.GetAllAsync(includeProperties: includeProperties,
            cancellationToken: cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(int id, string? includeProp = null,
        CancellationToken cancellationToken = default)
    {
        return await unitOfWork.CategoryRepository.GetAsync(c => c.Id == id, includeProperties: includeProp,
            cancellationToken: cancellationToken);
    }

    public async Task<OperationResult> CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await unitOfWork.CategoryRepository.AddAsync(category, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<OperationResult> UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await unitOfWork.CategoryRepository.UpdateAsync(category, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var category =
            await unitOfWork.CategoryRepository.GetAsync(c => c.Id == id, cancellationToken: cancellationToken);
        if (category == null)
        {
            return false;
        }

        await unitOfWork.CategoryRepository.DeleteAsync(category, cancellationToken);
        return true;
    }

    public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await unitOfWork.CategoryRepository.GetAsync(c => c.Name == name, cancellationToken: cancellationToken);
    }

    public async Task<IQueryable<Category>> FilterCategoryQueryable(CategoryOrderingEnum ordering, string? search)
    {
        var queryable = await unitOfWork.CategoryRepository.GetAllForPagnition(includeProperties: "Products");
        if (!string.IsNullOrEmpty(search))
            queryable = queryable.Where(x => x.Name.Contains(search));

        queryable = ordering switch
        {
            CategoryOrderingEnum.Id => queryable.OrderBy(x => x.Id),
            CategoryOrderingEnum.Name => queryable.OrderBy(x => x.Name),
            _ => queryable
        };
        return queryable;
    }
}