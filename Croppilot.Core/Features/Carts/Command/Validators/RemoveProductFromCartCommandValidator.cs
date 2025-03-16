using Croppilot.Core.Features.Carts.Command.Models;

namespace Croppilot.Core.Features.Carts.Command.Validators;

public class RemoveProductFromCartCommandValidator : AbstractValidator<RemoveProductFromCartCommand>
{
    private readonly IProductServices _productServices;

    public RemoveProductFromCartCommandValidator(IProductServices productServices)
    {
        _productServices = productServices;
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.")
            .MustAsync(ProductExists)
            .WithMessage("Product does not exist.");
    }

    private async Task<bool> ProductExists(int productId, CancellationToken cancellationToken)
    {
        return await _productServices.GetByIdAsync(productId, cancellationToken: cancellationToken) != null;
    }
}