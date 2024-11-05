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
                category = new Category
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
            if (result == "Success") return Created("Added Is Success");
            return BadRequest<string>();
        }

        public Task<Response<string>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<string>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {

            var result = await productServices.Delete(command.Id, cancellationToken);
            if (result == true) return Deleted<string>($"Delete Is Successfully For Product {command.Id}");
            return BadRequest<string>();
        }
    }
}
