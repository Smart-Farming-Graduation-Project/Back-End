using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Core.Features.Reviews.Command.Validators;

public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>
{
    public AddReviewCommandValidator(IProductServices productServices, IReviewRepository reviewRepository)
    {

        RuleFor(x => x.ProductID)
            .GreaterThan(0).WithMessage("ProductID must be greater than 0.")
            // Check if the product exists.
            .MustAsync(async (productId, cancellationToken) =>
                await productServices.GetByIdAsync(productId, cancellationToken: cancellationToken) != null)
            .WithMessage("Product does not exist.");

        RuleFor(x => x.Headline)
            .NotEmpty().WithMessage("Headline is required.")
            .MaximumLength(255).WithMessage("Headline cannot exceed 255 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.ReviewText)
            .NotEmpty().WithMessage("ReviewText is required.");
    }
}