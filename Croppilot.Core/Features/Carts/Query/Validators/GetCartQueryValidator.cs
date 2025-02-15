namespace Croppilot.Core.Features.Carts.Query.Validators;

public class GetCartQueryValidator : AbstractValidator<GetCartQuery>
{
    public GetCartQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}