namespace Croppilot.Infrastructure.Repositories.Implementation;

public class ReviewRepository(AppDbContext context) : GenericRepository<Review>(context), IReviewRepository
{
    public async Task<List<Review>> GetReviewsByProductIdAsync(int productId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Set<Review>()
            .Where(r => r.ProductID == productId)
            .ToListAsync(cancellationToken);
    }
}