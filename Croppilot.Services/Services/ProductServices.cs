using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class ProductServices(
    IUnitOfWork unit,
    IProductImageServices imageServices,
    IAzureBlobStorageService azureBlobStorage,
    ICategoryService categoryService) : IProductServices
{
    public async Task<IQueryable<Product>> GetAll(string[]? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var products = await unit.ProductRepository.GetForPaginationAsync(includeProperties: includeProperties);
        return products;
    }


    public async Task<Product?> GetByIdAsync(int id, string[]? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var product = await unit.ProductRepository.GetAsync(
            x => x.Id == id,
            includeProperties: includeProperties,
            tracked: false,
            cancellationToken: cancellationToken
        );

        return product;
    }

    public async Task<OperationResult> CreateAsync(Product product,
        CancellationToken cancellationToken = default)
    {

        var productExist = await unit.ProductRepository.GetProductsById(product.Id);


        if (productExist is not null)
            return OperationResult.IsAlreadyExist;

        await unit.ProductRepository.AddAsync(product, cancellationToken);

        return OperationResult.Success;
    }


    public async Task<OperationResult> UpdateAsync(Product product,
        CancellationToken cancellationToken = default)
    {
        var existingProduct = await unit.ProductRepository.GetAsync(
            x => x.Id == product.Id,
            includeProperties: ["ProductImages"],
            tracked: true,
            cancellationToken: cancellationToken
        );
        if (existingProduct == null)
            return OperationResult.NotFound;
        // Remove old images
        var existingImages = existingProduct.ProductImages?.ToList();
        if (existingImages != null && existingImages.Any())
        {
            await unit.ProductImageRepository.DeleteRangeAsync(existingImages, cancellationToken);
        }

        unit.ProductRepository.Detach(existingProduct); //detach if updating the whole object
        await unit.ProductRepository.UpdateAsync(product, cancellationToken);

        return OperationResult.Success;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var product = await unit.ProductRepository.GetProductsById(id);

        if (product == null)
            return false;

        // Delete images from Azure Blob Storage
        if (product.ProductImages != null && product.ProductImages.Any())
        {
            foreach (var productImage in product.ProductImages)
            {
                var filename = ExtractFileNameFromUrl(productImage.ImageUrl);
                if (!string.IsNullOrEmpty(filename))
                {
                    await azureBlobStorage.DeleteImageAsync(filename, "product-images");
                }
            }
        }

        await unit.ProductRepository.DeleteAsync(product, cancellationToken);
        return true;
    }


    public async Task<IQueryable<Product>> FilterProductQueryable(ProductOrderingEnum ordering, string? search)
    {
        var queryable = await unit.ProductRepository
            .GetForPaginationAsync(includeProperties: ["Category", "ProductImages"]);

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


    public IEnumerable<Product> GetByDate(int tt, DateOnly checkInDate)
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

	public Task<IQueryable<Product>> GetProductsByUserIdAsync(string userId, string[]? includeProperties = null, CancellationToken cancellationToken = default)
	{
		var products = unit.ProductRepository.GetForPaginationAsync(
			x => x.UserId == userId,
			includeProperties: includeProperties,
			false
		);
		return products;
	}
    private string ExtractFileNameFromUrl(string url)
    {
        return Path.GetFileName(new Uri(url).AbsolutePath);
    }
}