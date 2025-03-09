using Croppilot.Core.Features.Comments.Command.Models;

namespace Croppilot.Core.Features.Comments.Command.Validators;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator(ICommentService commentService)
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Comment ID must be greater than 0.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var comment = await commentService.GetCommentByIdAsync(id, cancellationToken);
                return comment != null;
            })
            .WithMessage("Comment not found.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
    }
}