using Croppilot.Core.Features.Posts.Query.Models;

namespace Croppilot.Core.Features.Posts.Query.Validators;

public class GetPostsByUserIdQueryValidator : AbstractValidator<GetPostsByUserIdQuery>
{
    public GetPostsByUserIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.")
            .NotNull().WithMessage("User ID cannot be null.");
    }
} 