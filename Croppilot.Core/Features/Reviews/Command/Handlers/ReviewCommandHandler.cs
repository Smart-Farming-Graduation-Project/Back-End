using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Reviews.Command.Handlers;

public class ReviewCommandHandler(IReviewService reviewService, IHttpContextAccessor contextAccessor) : ResponseHandler,
    IRequestHandler<AddReviewCommand, Response<string>>,
    IRequestHandler<DeleteReviewCommand, Response<string>>,
    IRequestHandler<UpdateReviewCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddReviewCommand command, CancellationToken cancellationToken)
    {
        var userId = GetCurrentAuthenticatedUserId();

        if (await reviewService.HasUserReviewedProductAsync(userId, command.ProductID, cancellationToken))
            return BadRequest<string>("User has already submitted a review for this product.");

        var review = command.Adapt<Review>();
        review.UserID = userId;

        var result = await reviewService.AddReviewAsync(review, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Review created successfully.")
            : BadRequest<string>("Failed to create review.");
    }

    public async Task<Response<string>> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
    {
        var userId = GetCurrentAuthenticatedUserId();

        var review = await reviewService.GetReviewByIdAsync(command.ReviewID, cancellationToken);

        if (review!.UserID != userId)
            return Unauthorized<string>("You are not authorized to delete this review.");

        var result =
            await reviewService.DeleteReviewAsync(command.ReviewID, userId, cancellationToken);

        return result == OperationResult.Success
            ? Success<string>("Review deleted successfully.")
            : Unauthorized<string>("You are not authorized to delete this review.");
    }

    public async Task<Response<string>> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
    {
        var userId = GetCurrentAuthenticatedUserId();

        var currentReview = await reviewService.GetReviewByIdAsync(command.ReviewID, cancellationToken);
        if (currentReview!.UserID != userId)
            return Unauthorized<string>("You are not authorized to update this review.");

        var review = command.Adapt<Review>();

        var result = await reviewService.UpdateReviewAsync(review, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Review updated successfully.")
            : BadRequest<string>("Failed to update review.");
    }

    private string GetCurrentAuthenticatedUserId()
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId();
        if (userId is null)
            throw new UnauthorizedAccessException("User is not authenticated.");

        return userId;
    }
}