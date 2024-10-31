using Croppilot.Date.DTOS;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class ProductServices(IUnitOfWork unit, IAzureBlobStorageService azureBlobStorage, ICategoryService categoryService) : IProductServices
{
    public async Task<List<GEtProductDTO>> GetAll(string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var products = await unit.ProductRepository.GetAllAsync(includeProperties: includeProperties,
            cancellationToken: cancellationToken);

        return products.Select(x => new GEtProductDTO
        {
            ProductId = x.Id,
            ProductName = x.Name,
            CategoryName = x.Category.Name,
            Price = x.Price,
            Availability = x.Availability.ToString()
        }).ToList();
    }



    public async Task<Product?> GetById(int id, string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        return await unit.ProductRepository.GetAsync(x => x.Id == id, includeProperties: includeProperties,
            cancellationToken: cancellationToken);
    }



    public async Task CreateAsync(CreateProductDTO productDto, CancellationToken cancellationToken = default)
    {
        var category = await categoryService.GetByNameAsync(productDto.CategoryName);
        if (category == null)
        {
            await categoryService.CreateAsync(new Category
            {
                Name = productDto.CategoryName
            }, cancellationToken);
        }
        var imageUrls = await azureBlobStorage.UploadImagesAsync(productDto.Images, productDto.Name);
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Availability = productDto.Availability,
            CategoryId = category.Id,
            ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        await unit.ProductRepository.AddAsync(product, cancellationToken);
        var productImages = imageUrls.Select(url => new ProductImage
        {
            ImageUrl = url,
            ProductId = product.Id
        }).ToList();

        foreach (var productImage in productImages)
        {
            await unit.ProductImageRepository.AddAsync(productImage, cancellationToken);
        }

    }


    public async Task UpdateAsync(int id, UpdateProductDTO productDto, CancellationToken cancellationToken = default)
    {
        var product = await GetById(id, includeProperties: "Category,ProductImages", cancellationToken: cancellationToken);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;
        product.Availability = productDto.Availability;

        if (productDto.Images != null && productDto.Images.Any())
        {
            var imageUrls = await azureBlobStorage.UploadImagesAsync(productDto.Images, productDto.Name);
            product.ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList();
        }
        product.UpdatedAt = DateTime.UtcNow;

        await unit.ProductRepository.UpdateAsync(product, cancellationToken);
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var product = await GetById(id, includeProperties: "ProductImages", cancellationToken: cancellationToken);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        foreach (var productImage in product.ProductImages)
        {
            await azureBlobStorage.DeleteImageAsync(productImage.ImageUrl);
        }
        await unit.ProductRepository.DeleteAsync(product, cancellationToken);
        return true;
    }

    public IEnumerable<Product> GetByDate(int nights, DateOnly checkInDate)
    {
        //Todo: Implement it
        throw new NotImplementedException();
    }

    public bool IsAvailableForLeasing(int villaId)
    {
        //Todo: Implement it
        throw new NotImplementedException();
    }
}