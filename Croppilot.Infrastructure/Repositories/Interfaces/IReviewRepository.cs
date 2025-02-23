namespace Croppilot.Infrastructure.Repositories.Interfaces;

public interface IReviewRepository : IGenericRepository<Review>
{
    Task<List<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<double> GetAverageRatingByProductIdAsync(int productId, CancellationToken cancellationToken = default);
}