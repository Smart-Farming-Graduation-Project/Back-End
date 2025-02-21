using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Date.Models;

namespace Croppilot.Core.Features.Reviews.Command.Handlers
{
    public class ReviewCommandHandler(IReviewService reviewService) : ResponseHandler,
        IRequestHandler<AddReviewCommand, Response<string>>,
        IRequestHandler<DeleteReviewCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                UserID = command.UserID,
                ProductID = command.ProductID,
                Headline = command.Headline,
                Rating = command.Rating,
                ReviewText = command.ReviewText,
                ReviewDate = DateTime.UtcNow
            };

            var result = await reviewService.AddReviewAsync(review, cancellationToken);
            return result == OperationResult.Success
                ? Success<string>("Review created successfully.")
                : BadRequest<string>("Failed to create review.");
        }

        public async Task<Response<string>> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
        {
            var result = await reviewService.DeleteReviewAsync(command.ReviewID, command.CurrentUserID, cancellationToken);
            return result == OperationResult.Success
                ? Success<string>("Review deleted successfully.")
                : Unauthorized<string>("You are not authorized to delete this review.");
        }
    }
}