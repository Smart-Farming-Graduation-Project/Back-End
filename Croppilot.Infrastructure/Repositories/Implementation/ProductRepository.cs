namespace Croppilot.Infrastructure.Repositories.Implementation;

public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    private readonly DbSet<Product> _product = context.Set<Product>();

    //for ex 
    public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _context.Set<Product>()
            .Where(p => p.CategoryId == categoryId)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Product?> GetProductsById(int id)
    {
        return await _context.Set<Product>()
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.ProductImages)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    //public override async Task<List<Product>> GetAll()
    //{
    //    return await _context.Products
    //        .Include(p => p.Category)
    //        .Include(P => P.Leasings)
    //        .Include(p => p.ProductImages)
    //        .ToListAsync();
    //}

    //public override async Task<Product?> GetById(int id)
    //{
    //    return await _context.Products
    //        .Include(p => p.Category)
    //        .Include(P => P.Leasings)
    //        .Include(p => p.ProductImages)
    //        .SingleOrDefaultAsync(p => p.Id == id);
    //}
}