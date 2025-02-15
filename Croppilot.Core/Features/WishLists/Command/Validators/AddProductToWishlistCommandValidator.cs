using Croppilot.Core.Features.WishLists.Command.Models;

namespace Croppilot.Core.Features.WishLists.Command.Validators;

public class AddProductToWishlistCommandValidator : AbstractValidator<AddProductToWishlistCommand>
{
    public AddProductToWishlistCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
    }
}