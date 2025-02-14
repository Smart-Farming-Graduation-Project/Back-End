using Croppilot.Core.Features.WishLists.Command.Models;

namespace Croppilot.Core.Features.WishLists.Command.Validators;

public class CreateWishlistCommandValidator : AbstractValidator<CreateWishlistCommand>
{
    public CreateWishlistCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.WishlistItems)
            .NotNull().WithMessage("Wishlist items cannot be null.")
            .Must(items => items.Count != 0)
            .WithMessage("At least one wishlist item is required.");

        RuleForEach(x => x.WishlistItems)
            .SetValidator(new CreateWishlistItemCommandValidator());
    }
}

public class CreateWishlistItemCommandValidator : AbstractValidator<CreateWishlistItemCommand>
{
    public CreateWishlistItemCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.");
    }
}