using Croppilot.Core.Features.Posts.Command.Models;

namespace Croppilot.Core.Features.Posts.Command.Validators;

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator(IPostService postService)
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Post ID must be greater than 0.");

        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var post = await postService.GetPostByIdAsync(id, cancellationToken);
                return post != null;
            })
            .WithMessage("Post not found.");
    }
}