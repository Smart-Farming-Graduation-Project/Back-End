namespace Croppilot.Services.Abstract;

public interface IReviewService
{
    Task<OperationResult> AddReviewAsync(Review review, CancellationToken cancellationToken = default);
    Task<List<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<Review?> GetReviewByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<OperationResult> DeleteReviewAsync(int reviewId, string currentUserId,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateReviewAsync(Review review,
        CancellationToken cancellationToken = default);

    Task<double> GetAverageRatingByProductIdAsync(int productId, CancellationToken cancellationToken = default);

    Task<bool> HasUserReviewedProductAsync(string userId, int productId, CancellationToken cancellationToken = default);
}