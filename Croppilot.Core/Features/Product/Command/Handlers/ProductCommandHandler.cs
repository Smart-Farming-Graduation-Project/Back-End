using Croppilot.Date.Models;
using Croppilot.Services.Abstract;
using Mapster;

namespace Croppilot.Core.Features.Product.Command.Handlers;

public class ProductCommandHandler(
    IProductServices productServices,
    ICategoryService categoryService,
    IAzureBlobStorageService azureService)
    : ResponseHandler,
        IRequestHandler<AddProductCommand, Response<string>>,
        IRequestHandler<EditProductCommand, Response<string>>,
        IRequestHandler<DeleteProductCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        var category = await EnsureCategoryExists(command.CategoryName, cancellationToken);

        var imageUrls = await azureService.UploadImagesAsync(command.Images, command.Name);

        var product = command.Adapt<Date.Models.Product>(); // Mapping using Mapster
        product.CategoryId = category.Id; // Ensure category is linked
        product.ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList();
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = default; //it should be null when created,set now only when product is updated  


        var result = await productServices.CreateAsync(product, imageUrls, cancellationToken);
        return result is OperationResult.Success
            ? Created("Product Added Successfully")
            : BadRequest<string>("Product creation failed");
    }

    public async Task<Response<string>> Handle(EditProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productServices.GetById(command.Id, ["Category", "ProductImages"], cancellationToken);
        if (product == null)
            return NotFound<string>("Product Not Found");

        var category = await EnsureCategoryExists(command.CategoryName, cancellationToken);
        var imageUrls = await HandleProductImageUpdates(product, command.Images);

        product = command.Adapt(product); // update product with new values from command

        product.CategoryId = category.Id;
        product.ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList();
        product.UpdatedAt = DateTime.UtcNow;

        var result = await productServices.UpdateAsync(product, imageUrls, cancellationToken);
        return result is OperationResult.Success
            ? Success("Product Updated Successfully")
            : BadRequest<string>("Failed to Update Product");
    }

    public async Task<Response<string>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Date.Models.Product>();

        var existingProduct =
            await productServices.GetById(product.Id, includeProperties: ["ProductImages"], cancellationToken);

        if (existingProduct is null)
            return NotFound<string>($"Product {product.Id} not found");

        await RemoveProductImagesFromStorage(existingProduct.ProductImages);

        var result = await productServices.Delete(product.Id, cancellationToken);
        return result
            ? Deleted<string>($"Product {product.Id} Deleted Successfully")
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

    private async Task<List<string>> HandleProductImageUpdates(Date.Models.Product product,
        IFormFileCollection? newImages)
    {
        if (newImages is { Count: > 0 })
        {
            await RemoveProductImagesFromStorage(product.ProductImages);
            return await azureService.UploadImagesAsync(newImages, product.Name);
        }

        return product.ProductImages.Select(pi => pi.ImageUrl).ToList();
    }

    private async Task RemoveProductImagesFromStorage(ICollection<ProductImage> productImages)
    {
        await Parallel.ForEachAsync(productImages, async (productImage, _) =>
        {
            var path = Path.GetFileName(new Uri(productImage.ImageUrl).AbsolutePath);
            await azureService.DeleteImageAsync(path);
        });
    }
}