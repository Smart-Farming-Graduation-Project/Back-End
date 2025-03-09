using Croppilot.Core.Features.Comments.Command.Models;

namespace Croppilot.Core.Features.Comments.Command.Validators;

public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentCommandValidator(ICommentService commentService)
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Comment ID must be greater than 0.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var comment = await commentService.GetCommentByIdAsync(id, cancellationToken);
                return comment != null;
            })
            .WithMessage("Comment not found.");
    }
}