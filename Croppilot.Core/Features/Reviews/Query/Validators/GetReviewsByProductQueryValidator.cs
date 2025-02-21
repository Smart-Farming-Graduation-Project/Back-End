using Croppilot.Core.Features.Reviews.Query.Models;

namespace Croppilot.Core.Features.Reviews.Query.Validators;

public class GetReviewsByProductQueryValidator : AbstractValidator<GetReviewsByProductQuery>
{
    public GetReviewsByProductQueryValidator(IProductServices productServices)
    {
        RuleFor(x => x.ProductID)
            .GreaterThan(0)
            .WithMessage("ProductID must be greater than 0.")
            .MustAsync(async (productId, cancellationToken) =>
                await productServices.GetByIdAsync(productId, cancellationToken: cancellationToken) != null)
            .WithMessage("Product does not exist.");
    }
}