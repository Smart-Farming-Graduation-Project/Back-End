using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Core.Features.Reviews.Command.Validators;

public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator(IReviewRepository reviewRepository)
    {
        RuleFor(x => x.ReviewID)
            .GreaterThan(0).WithMessage("ReviewID must be greater than 0.")
            .MustAsync(async (reviewId, cancellationToken) =>
            {
                var review = await reviewRepository.GetAsync(r => r.ReviewID == reviewId,
                    cancellationToken: cancellationToken);
                return review != null;
            }).WithMessage("Review not found.");

        RuleFor(x => x.CurrentUserID)
            .NotEmpty().WithMessage("User is not authenticated.");

        // Ensure the review belongs to the current user.
        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                var review = await reviewRepository.GetAsync(r => r.ReviewID == command.ReviewID,
                    cancellationToken: cancellationToken);
                return review != null && review.UserID == command.CurrentUserID;
            }).WithMessage("You are not authorized to delete this review.");
    }
}