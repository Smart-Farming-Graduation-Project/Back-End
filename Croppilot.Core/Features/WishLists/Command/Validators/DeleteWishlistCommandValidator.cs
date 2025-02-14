using Croppilot.Core.Features.WishLists.Command.Models;

namespace Croppilot.Core.Features.WishLists.Command.Validators;

public class DeleteWishlistCommandValidator : AbstractValidator<DeleteWishlistCommand>
{
    public DeleteWishlistCommandValidator()
    {
        RuleFor(x => x.WishlistId)
            .GreaterThan(0)
            .WithMessage("WishlistId must be greater than 0.");
    }
}