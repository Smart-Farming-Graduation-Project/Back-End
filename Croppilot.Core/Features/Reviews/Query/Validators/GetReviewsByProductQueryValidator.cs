using Croppilot.Core.Features.Reviews.Query.Models;

namespace Croppilot.Core.Features.Reviews.Query.Validators;

public class GetReviewsByProductQueryValidator : AbstractValidator<GetReviewsByProductQuery>
{
    private readonly IProductServices _productServices;

    public GetReviewsByProductQueryValidator(IProductServices productServices)
    {
        _productServices = productServices;
        RuleFor(x => x.ProductID)
            .GreaterThan(0)
            .WithMessage("ProductID must be greater than 0.")
            .MustAsync(ProductExists)
            .WithMessage("Product does not exist.");
    }

    private async Task<bool> ProductExists(int productId, CancellationToken cancellationToken)
    {
        return await _productServices.GetByIdAsync(productId, cancellationToken: cancellationToken) != null;
    }
}