using Croppilot.Core.Features.WishLists.Query.Models;

namespace Croppilot.Core.Features.WishLists.Query.Validators;

public class GetWishlistQueryValidator : AbstractValidator<GetWishlistQuery>
{
    public GetWishlistQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}