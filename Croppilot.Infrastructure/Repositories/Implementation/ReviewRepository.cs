namespace Croppilot.Infrastructure.Repositories.Implementation;

public class ReviewRepository(AppDbContext context) : GenericRepository<Review>(context), IReviewRepository
{
    public async Task<List<Review>> GetReviewsByProductIdAsync(int productId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Set<Review>()
            .Where(r => r.ProductID == productId).Include(r => r.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<double> GetAverageRatingByProductIdAsync(int productId,
        CancellationToken cancellationToken = default)
    {
        var ratings = await _context.Set<Review>()
            .Where(r => r.ProductID == productId)
            .Select(r => r.Rating)
            .ToListAsync(cancellationToken);


        return ratings.Count != 0 ? ratings.Average() : 5;
    }
}