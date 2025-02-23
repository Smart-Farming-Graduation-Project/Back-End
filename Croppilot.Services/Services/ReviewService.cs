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

        await reviewRepository.DeleteAsync(review!, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<OperationResult> UpdateReviewAsync(Review review,
        CancellationToken cancellationToken = default)
    {
        var currentReview = await reviewRepository.GetAsync(r => r.ReviewID == review.ReviewID,
            cancellationToken: cancellationToken);

        if (currentReview == null)
            return OperationResult.Failure;

        currentReview.Headline = review.Headline;
        currentReview.Rating = review.Rating;
        currentReview.ReviewText = review.ReviewText;
        currentReview.UpdatedAt = DateTime.UtcNow;

        await reviewRepository.UpdateAsync(currentReview, cancellationToken);
        return OperationResult.Success;
    }

    public Task<double> GetAverageRatingByProductIdAsync(int productId, CancellationToken cancellationToken = default)
    {
        return reviewRepository.GetAverageRatingByProductIdAsync(productId, cancellationToken);
    }
}