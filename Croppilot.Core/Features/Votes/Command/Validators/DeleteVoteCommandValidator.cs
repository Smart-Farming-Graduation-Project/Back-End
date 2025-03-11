using Croppilot.Core.Features.Votes.Command.Models;

namespace Croppilot.Core.Features.Votes.Command.Validators;

public class DeleteVoteCommandValidator : AbstractValidator<DeleteVoteCommand>
{
    public DeleteVoteCommandValidator()
    {
        RuleFor(x => x.TargetId)
            .GreaterThan(0).WithMessage("Target ID must be greater than 0.");

        RuleFor(x => x.TargetType)
            .NotEmpty().WithMessage("Target type is required.")
            .Must(type => type.Equals("post", StringComparison.CurrentCultureIgnoreCase) ||
                          type.Equals("comment", StringComparison.CurrentCultureIgnoreCase))
            .WithMessage("Target type must be either 'post' or 'comment'.");
    }
}