using Croppilot.Core.Features.WishLists.Command.Models;

namespace Croppilot.Core.Features.WishLists.Command.Validators
{
    public class RemoveProductFromWishlistCommandValidator : AbstractValidator<RemoveProductFromWishlistCommand>
    {
        public RemoveProductFromWishlistCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}