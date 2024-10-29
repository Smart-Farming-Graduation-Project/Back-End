using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class ProductServices(IUnitOfWork unit) : IProductServices
{
    public async Task<List<Product>> GetAll(string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        return await unit.ProductRepository.GetAllAsync(includeProperties: includeProperties,
            cancellationToken: cancellationToken);
    }

    public async Task<Product?> GetById(int id, string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        return await unit.ProductRepository.GetAsync(x => x.Id == id, includeProperties: includeProperties,
            cancellationToken: cancellationToken);
    }

    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
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