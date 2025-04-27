using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class CategoryService(IUnitOfWork unitOfWork, IAzureBlobStorageService azureBlobStorageService) : ICategoryService
{
	public async Task<List<Category>> GetAllAsync(string[]? includeProperties = null,
		CancellationToken cancellationToken = default)
	{
		return await unitOfWork.CategoryRepository.GetAllAsync(includeProperties: includeProperties,
			cancellationToken: cancellationToken);
	}

	public async Task<Category?> GetByIdAsync(int id, string[]? includeProperties = null,
		CancellationToken cancellationToken = default)
	{
		return await unitOfWork.CategoryRepository.GetAsync(c => c.Id == id, includeProperties: includeProperties,
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
		string imageUrl = category.ImageUrl;
		await RemoveCtaegoryImage(imageUrl);
		await unitOfWork.CategoryRepository.DeleteAsync(category, cancellationToken);
		return true;
	}

	public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
	{
		return await unitOfWork.CategoryRepository.GetAsync(c => c.Name == name, cancellationToken: cancellationToken);
	}

	public async Task<IQueryable<Category>> FilterCategoryQueryable(CategoryOrderingEnum ordering, string? search)
	{
		var queryable = await unitOfWork.CategoryRepository.GetForPaginationAsync(includeProperties: ["Products"]);
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

	public async Task UploadImageAndUpdateCategory(int categoryId, byte[] image, string extension)
	{
		var category = await unitOfWork.CategoryRepository.GetAsync(c => c.Id == categoryId);
		if (category == null)
			throw new Exception($"Category with ID {categoryId} not found");
		await UploadNewCategoryImage(category, image, extension);
	}

	public async Task ChangeCategoryImageAndUpdateCategory(int categoryId, byte[] image, string extension)
	{
		var category = await unitOfWork.CategoryRepository.GetAsync(c => c.Id == categoryId);
		if (category == null)
			throw new Exception($"Category with ID {categoryId} not found");
		string imageUrl = category.ImageUrl;
		await RemoveCtaegoryImage(imageUrl);
		await UploadNewCategoryImage(category, image, extension);
	}

	private async Task RemoveCtaegoryImage(string imageUrl)
	{
		if (string.IsNullOrEmpty(imageUrl))
			return;
		var blobName = GetBlobName(imageUrl);
		await azureBlobStorageService.DeleteImageAsync(blobName, "category-images");
	}
	private string GetBlobName(string imageUrl)
	{
		return imageUrl.Split('/').Last();
	}

	private async Task UploadNewCategoryImage(Category category, byte[] image, string extension)
	{
		using var stream = new MemoryStream(image);
		var newImageUrl = await azureBlobStorageService.UploadImageAsync(stream,
					   "category-images",
					   $"{Guid.NewGuid().ToString()}_{category.Name}{extension}");
		category.ImageUrl = newImageUrl;
		await unitOfWork.CategoryRepository.UpdateAsync(category);
	}
}