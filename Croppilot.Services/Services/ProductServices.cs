using Croppilot.Date.DTOS;
using Croppilot.Date.Enum;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class ProductServices(IUnitOfWork unit, IAzureBlobStorageService azureBlobStorage, ICategoryService categoryService) : IProductServices
{
    public async Task<IQueryable<Product>> GetAll(string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var products = await unit.ProductRepository.GetAllForPagnition(includeProperties: includeProperties);
        return products;
    }



    public async Task<Product?> GetById(int id, string? includeProperties = null,
      CancellationToken cancellationToken = default)
    {
        var product = await unit.ProductRepository.GetAsync(
            x => x.Id == id,
            includeProperties: includeProperties,
            cancellationToken: cancellationToken
        );

        return product;
    }
    public async Task<string> CreateAsync(Product product, List<string> imageList, CancellationToken cancellationToken = default)
    {
        //var category = await categoryService.GetByNameAsync(productDto.CategoryName);
        //if (category == null)
        //{
        //    await categoryService.CreateAsync(new Category
        //    {
        //        Name = productDto.CategoryName,
        //        Description = productDto.CategoryName
        //    }, cancellationToken);
        //}
        //var imageUrls = await azureBlobStorage.UploadImagesAsync(productDto.Images, productDto.Name);
        //var product = new Product
        //{
        //    Name = productDto.Name,
        //    Description = productDto.Description,
        //    Price = productDto.Price,
        //    Availability = productDto.Availability,
        //    CategoryId = category.Id,
        //    ProductImages = imageUrls.Select(url => new ProductImage { ImageUrl = url }).ToList(),
        //    CreatedAt = DateTime.UtcNow,
        //    UpdatedAt = DateTime.UtcNow
        //};
        var productExist = await unit.ProductRepository.GetProductsById(product.Id);

        if (productExist is not null)
            return "Exist";
        await unit.ProductRepository.AddAsync(product, cancellationToken);
        var productImages = imageList.Select(url => new ProductImage
        {
            ImageUrl = url,
            ProductId = product.Id
        }).ToList();

        foreach (var productImage in productImages)
        {
            await unit.ProductImageRepository.AddAsync(productImage, cancellationToken);
        }
        return "Success";
    }
    public async Task UpdateAsync(int id, UpdateProductDTO productDto, CancellationToken cancellationToken = default)
    {
        var product = await unit.ProductRepository.GetProductsById(id);
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
        var product = await unit.ProductRepository.GetProductsById(id);
        if (product == null)
        {
            return false;
        }
        foreach (var productImage in product.ProductImages)
        {
            var filename = ExtractFileNameFromUrl(productImage.ImageUrl);
            await azureBlobStorage.DeleteImageAsync(filename);
        }
        await unit.ProductRepository.DeleteAsync(product, cancellationToken);
        return true;
    }

    public async Task<IQueryable<Product>> FilterProductQueryable(ProductOrderingEnum ordering, string? search)
    {
        var queryable = await unit.ProductRepository.GetAllForPagnition(includeProperties: "Category,ProductImages");
        if (!string.IsNullOrEmpty(search))
            queryable = queryable.Where(x => x.Name.Contains(search) || x.Category.Name.Contains(search));

        queryable = ordering switch
        {
            ProductOrderingEnum.Id => queryable.OrderBy(x => x.Id),
            ProductOrderingEnum.Name => queryable.OrderBy(x => x.Name),
            ProductOrderingEnum.Category => queryable.OrderBy(x => x.Category.Name),
            ProductOrderingEnum.Price => queryable.OrderBy(x => x.Price),
            ProductOrderingEnum.Availability => queryable.OrderBy(x => x.Availability),
            ProductOrderingEnum.CreatedAt => queryable.OrderBy(x => x.CreatedAt),
            ProductOrderingEnum.UpdatedAt => queryable.OrderBy(x => x.UpdatedAt),
            _ => queryable
        };
        return queryable;
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

    private string ExtractFileNameFromUrl(string url)
    {
        return Path.GetFileName(new Uri(url).AbsolutePath);
    }
}