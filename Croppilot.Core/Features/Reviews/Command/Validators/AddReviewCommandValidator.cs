using Croppilot.Core.Features.Reviews.Command.Models;

namespace Croppilot.Core.Features.Reviews.Command.Validators;

public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>
{
    public AddReviewCommandValidator(IProductServices productServices)
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
            .InclusiveBetween(1.0, 5.0).WithMessage("Rating must be between 1.0 and 5.0.");

        RuleFor(x => x.ReviewText)
            .NotEmpty().WithMessage("ReviewText is required.");
    }
}