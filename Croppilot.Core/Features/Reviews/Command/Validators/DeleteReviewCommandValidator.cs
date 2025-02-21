using Croppilot.Core.Features.Reviews.Command.Models;

namespace Croppilot.Core.Features.Reviews.Command.Validators;

public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(x => x.ReviewID)
            .GreaterThan(0).WithMessage("ReviewID must be greater than 0.");

        RuleFor(x => x.CurrentUserID)
            .NotEmpty().WithMessage("CurrentUserID is required.");
    }
}