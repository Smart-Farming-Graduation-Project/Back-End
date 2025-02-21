using FluentValidation;
using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Core.Features.Reviews.Command.Validators;

public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator(IReviewRepository reviewRepository)
    {
        RuleFor(x => x.ReviewID)
            .GreaterThan(0).WithMessage("ReviewID must be greater than 0.")
            // Ensure the review exists.
            .MustAsync(async (reviewId, cancellationToken) =>
            {
                var review = await reviewRepository.GetAsync(r => r.ReviewID == reviewId,
                    cancellationToken: cancellationToken);
                return review != null;
            }).WithMessage("Review does not exist.");

        RuleFor(x => x.Headline)
            .NotEmpty().WithMessage("Headline is required.")
            .MaximumLength(255).WithMessage("Headline cannot exceed 255 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.ReviewText)
            .NotEmpty().WithMessage("Review text is required.");

        RuleFor(x => x.CurrentUserID)
            .NotEmpty().WithMessage("User is not authenticated.");

        // Ensure the review belongs to the current user.
        RuleFor(x => x).MustAsync(async (command, cancellationToken) =>
        {
            var review = await reviewRepository.GetAsync(r => r.ReviewID == command.ReviewID,
                cancellationToken: cancellationToken);
            return review != null && review.UserID == command.CurrentUserID;
        }).WithMessage("You are not authorized to edit this review.");
    }
}