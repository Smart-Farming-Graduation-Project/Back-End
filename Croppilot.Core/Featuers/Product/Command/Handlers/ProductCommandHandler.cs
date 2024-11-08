using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Product.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Command.Handlers
{
    public class ProductCommandHandler(IProductServices productServices, ICategoryService categoryService, IAzureBlobStorageService azureService) : ResponseHandler,
        IRequestHandler<AddProductCommand, Response<string>>
        , IRequestHandler<EditProductCommand, Response<string>>
        , IRequestHandler<DeleteProductCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetByNameAsync(command.CategoryName);
            if (category == null)
            {
                category = new Date.Models.Category
                {
                    Name = command.CategoryName,
                    Description = command.CategoryName
                };
                await categoryService.CreateAsync(category, cancellationToken);
            }
            var imageUrls = await azureService.UploadImagesAsync(command.Images, command.Name);

            var product = new Date.Models.Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Availability = command.Availability,
                CategoryId = category.Id,
                ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var result = await productServices.CreateAsync(product, imageUrls, cancellationToken);
            return result == "Success" ? Created("Product Added Successfully") : BadRequest<string>();

        }

        public async Task<Response<string>> Handle(EditProductCommand command, CancellationToken cancellationToken)
        {
            var product = await productServices.GetById(command.Id, includeProperties: "Category,ProductImages", cancellationToken: cancellationToken);
            if (product == null)
            {
                return NotFound<string>("Product Not Found");
            }

            var category = await categoryService.GetByNameAsync(command.CategoryName);
            if (category == null)
            {
                category = new Date.Models.Category
                {
                    Name = command.CategoryName,
                    Description = "Description Is Empty"
                };
                await categoryService.CreateAsync(category, cancellationToken);
            }

            // Handle image updates
            List<string> imageUrls = product.ProductImages.Select(pi => pi.ImageUrl).ToList();
            if (command.Images != null && command.Images.Any())
            {
                // Delete old images from Azure storage if new images are provided
                foreach (var productImage in product.ProductImages)
                {
                    var path = Path.GetFileName(new Uri(productImage.ImageUrl).AbsolutePath);
                    await azureService.DeleteImageAsync(path);
                }

                // Upload new images
                imageUrls = await azureService.UploadImagesAsync(command.Images, command.Name);
            }
            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.Availability = command.Availability;
            product.CategoryId = category.Id;
            product.ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList();
            product.UpdatedAt = DateTime.UtcNow;

            var result = await productServices.UpdateAsync(product, imageUrls, cancellationToken);
            return result == "Success" ? Success("Product Updated Successfully") : BadRequest<string>("Failed to Update Product");

        }

        public async Task<Response<string>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {

            var result = await productServices.Delete(command.Id, cancellationToken);
            return result ? Deleted<string>($"Product {command.Id} Deleted Successfully") : BadRequest<string>("Product Not Found");

        }
    }
}
