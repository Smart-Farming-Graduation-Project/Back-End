using Croppilot.Date.DTOS;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class ProductServices(IUnitOfWork unit) : IProductServices
{
    public async Task<List<ProductDTO>> GetAll(string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var products = await unit.ProductRepository.GetAllAsync(includeProperties: includeProperties,
            cancellationToken: cancellationToken);

        return products.Select(x => new ProductDTO
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

    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        // var imageUrl = await _blobService.UploadImageAsync(image);
        //var productImage = new ProductImage
        //{
        //    ProductId = productId,
        //    ImageUrl = imageUrl
        //};

        await unit.ProductRepository.AddAsync(product, cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await unit.ProductRepository.UpdateAsync(product, cancellationToken);
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var product = await unit.ProductRepository.GetAsync(x => x.Id == id, cancellationToken: cancellationToken);
        if (product != null)
        {
            await unit.ProductRepository.DeleteAsync(product, cancellationToken);
            return true;
        }

        return false;
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