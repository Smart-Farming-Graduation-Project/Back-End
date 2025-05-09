using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;
using Hangfire;

namespace Croppilot.Core.Features.Product.Command.Handlers;

public class ProductCommandHandler(
	IProductServices productServices,
	ICategoryService categoryService,
	IProductImageServices productImageServices,
	IAzureBlobStorageService azureService,
	IHttpContextAccessor httpContextAccessor)
	: ResponseHandler,
		IRequestHandler<AddProductCommand, Response<string>>,
		IRequestHandler<EditProductCommand, Response<string>>,
		IRequestHandler<DeleteProductCommand, Response<string>>
{
	public async Task<Response<string>> Handle(AddProductCommand command, CancellationToken cancellationToken)
	{
		var category = await EnsureCategoryExists(command.CategoryName, cancellationToken);

		var userId = httpContextAccessor?.HttpContext?.User.GetUserId()!;

		var product = command.Adapt<Date.Models.Product>();
		product.CategoryId = category.Id;
		product.UserId = userId;
		product.CreatedAt = DateTime.UtcNow;
		product.UpdatedAt = default;
		var result = await productServices.CreateAsync(product, cancellationToken);
		if (result is not OperationResult.Success)
			return BadRequest<string>("Product creation failed");

		var tempFilePaths = await productImageServices.SaveFilesTemporarily(command.Images);


		BackgroundJob.Enqueue(() => productImageServices.UploadImagesAndUpdateProduct(product.Id, tempFilePaths, product.Name));

		return result is OperationResult.Success
			? Created("Product Added Successfully")
			: BadRequest<string>("Product creation failed");
	}

	public async Task<Response<string>> Handle(EditProductCommand command, CancellationToken cancellationToken)
	{
		var userId = httpContextAccessor?.HttpContext?.User.GetUserId()!;
		var product = await productServices.GetByIdAsync(command.Id, ["Category", "ProductImages"], cancellationToken);
		if (product == null)
			return NotFound<string>("Product Not Found");

		if (product.UserId != userId)
			return Unauthorized<string>("You are not authorized to edit this product");

		var category = await EnsureCategoryExists(command.CategoryName, cancellationToken);

		var oldImageUrls = product.ProductImages.Select(pi => pi.ImageUrl).ToList();

		product = command.Adapt(product); // update product with new values from command

		product.CategoryId = category.Id;

		product.UpdatedAt = DateTime.UtcNow;
		//delete old image
		if (product.ProductImages is not null)
			await RemoveProductImagesFromStorage(product.ProductImages, product.Id);


		var tempFilePaths = await productImageServices.SaveFilesTemporarily(command.Images);
		var result = await productServices.UpdateAsync(product, cancellationToken);
		BackgroundJob.Enqueue(() => productImageServices.UploadImagesAndUpdateProduct(product.Id, tempFilePaths, product.Name));

		return result is OperationResult.Success
			? Success("Product Updated Successfully")
			: BadRequest<string>("Failed to Update Product");
	}

	public async Task<Response<string>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
	{
		var userId = httpContextAccessor?.HttpContext?.User.GetUserId()!;

		var existingProduct = await productServices.GetByIdAsync(command.Id, ["ProductImages"]);

		if (existingProduct is null)
			return NotFound<string>($"Product {command.Id} not found");

		if (existingProduct.UserId != userId)
			return Unauthorized<string>("You are not authorized to delete this product");

		await RemoveProductImagesFromStorage(existingProduct.ProductImages, command.Id);
		var result = await productServices.Delete(command.Id, cancellationToken);
		return result
			? Deleted<string>($"Product {command.Id} Deleted Successfully")
			: BadRequest<string>("Deletion failed");
	}


	private async Task<Date.Models.Category> EnsureCategoryExists(string categoryName,
		CancellationToken cancellationToken)
	{
		var category = await categoryService.GetByNameAsync(categoryName, cancellationToken);

		if (category != null) return category;

		var newCategory = new Date.Models.Category
		{
			Name = categoryName,
			Description = "No description",
		};

		var result = await categoryService.CreateAsync(newCategory, cancellationToken);
		return result is OperationResult.Success ? newCategory : throw new Exception("Category creation failed.");
	}

	//private async Task<List<string>> HandleProductImageUpdates(Date.Models.Product product,
	//    List<string>? newImages)
	//{
	//    if (newImages is { Count: > 0 })
	//    {
	//        await RemoveProductImagesFromStorage(product.ProductImages);
	//        return await azureService.UploadImagesAsync(newImages, product.Name);
	//    }

	//    return product.ProductImages.Select(pi => pi.ImageUrl).ToList();
	//}

	private async Task RemoveProductImagesFromStorage(List<ProductImage> productImages, int productId)
	{
		await productImageServices.DeleteImagesAsync(productId);

		await Parallel.ForEachAsync(productImages, async (productImage, _) =>
		{
			var path = Path.GetFileName(new Uri(productImage.ImageUrl).AbsolutePath);
			await azureService.DeleteImageAsync(path, "product-images");
		});
	}

}