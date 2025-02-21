namespace Croppilot.Services.Abstract;

public interface IReviewService
{
    Task<OperationResult> AddReviewAsync(Review review, CancellationToken cancellationToken = default);
    Task<List<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<OperationResult> DeleteReviewAsync(int reviewId, CancellationToken cancellationToken = default);
}