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
            .InclusiveBetween(1.0, 5.0).WithMessage("Rating must be between 1.0 and 5.0.");

        RuleFor(x => x.ReviewText)
            .MaximumLength(500).WithMessage("ReviewText cannot exceed 500 characters.");
    }
}