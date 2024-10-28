using Croppilot.Date.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services
{
    public class ProductServices(IUnitOfWork unit) : IProductServices
    {


        public async Task<List<Product>> GetAllProduct(string? includeProp = null)
        {
            return await unit.ProductRepository.GetAllAsync(includeProperty: includeProp);
        }

        public async Task<Product> GetProductById(int id, string? includeProp = null)
        {
            return await unit.ProductRepository.GetAsync(x => x.Id == id, includeProperty: includeProp);
        }

        public Task CreateAsync(Product villa)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product villa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductByDate(int nights, DateOnly checkInDate)
        {
            throw new NotImplementedException();
        }

        public bool IsProductAvailableForLeasing(int villaId)
        {
            throw new NotImplementedException();
        }
    }
}
