using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    public async Task<OperationResult> AddReviewAsync(Review review, CancellationToken cancellationToken = default)
    {
        await reviewRepository.AddAsync(review, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<List<Review>> GetReviewsByProductIdAsync(int productId,
        CancellationToken cancellationToken = default)
    {
        return await reviewRepository.GetReviewsByProductIdAsync(productId, cancellationToken);
    }

    public async Task<OperationResult> DeleteReviewAsync(int reviewId, string currentUserId,
        CancellationToken cancellationToken = default)
    {
        var review = await reviewRepository.GetAsync(r => r.ReviewID == reviewId, cancellationToken: cancellationToken);
        if (review == null)
            return OperationResult.Failure;

        if (review.UserID != currentUserId)
            return OperationResult.Failure;

        await reviewRepository.DeleteAsync(review, cancellationToken);
        return OperationResult.Success;
    }
}