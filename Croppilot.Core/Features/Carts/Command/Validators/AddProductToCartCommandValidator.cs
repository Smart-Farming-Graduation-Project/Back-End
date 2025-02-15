using Croppilot.Core.Features.Carts.Command.Models;

namespace Croppilot.Core.Features.Carts.Command.Validators;

public class AddProductToCartCommandValidator : AbstractValidator<AddProductToCartCommand>
{
    public AddProductToCartCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.");
    }
}

public class RemoveProductFromCartCommandValidator : AbstractValidator<RemoveProductFromCartCommand>
{
    public RemoveProductFromCartCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.");
    }
}