using Croppilot.Date.Models;
using Croppilot.Infrastructure.Data;
using Croppilot.Infrastructure.Generics.Implementation;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public override async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(P => P.Leasings)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }

        public override async Task<Product?> GetById(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(P => P.Leasings)
                .Include(p => p.ProductImages)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
