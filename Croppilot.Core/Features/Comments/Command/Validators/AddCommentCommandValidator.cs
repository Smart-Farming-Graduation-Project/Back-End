using Croppilot.Core.Features.Comments.Command.Models;

namespace Croppilot.Core.Features.Comments.Command.Validators;

public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
{
    public AddCommentCommandValidator(IPostService postService, ICommentService commentService)
    {
        RuleFor(x => x.PostId)
            .GreaterThan(0).WithMessage("Post ID must be greater than 0.")
            .MustAsync(async (postId, cancellationToken) =>
            {
                var post = await postService.GetPostByIdAsync(postId, cancellationToken);
                return post != null;
            })
            .WithMessage("Post not found.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.ParentCommentId)
            .Must(id => id is null or 0 or > 0)
            .WithMessage("Parent comment ID must be either 0 (for no parent) or a valid positive id.");

        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                if (command.ParentCommentId is null or 0)
                    return true;
                var parentComment = await commentService.GetCommentByIdAsync(command.ParentCommentId.Value, cancellationToken);
                return parentComment != null;
            })
            .WithMessage("Parent comment not found.");
    }
}