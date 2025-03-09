using Croppilot.Core.Features.Posts.Command.Models;

namespace Croppilot.Core.Features.Posts.Command.Validators;

public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator(IPostService postService)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title cannot exceed 255 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        // Validate SharedPostId: It must be null, or 0 (which means no share), or a valid existing post id.
        RuleFor(x => x.SharedPostId)
            .Must(id => id is null or 0 or > 0)
            .WithMessage("SharedPostId must be either 0 (for no share) or a valid positive id.");

        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                // If a SharedPostId is provided (and not 0), ensure it exists.
                if (command.SharedPostId is null or 0)
                    return true;
                
                var sharedPost = await postService.GetPostByIdAsync(command.SharedPostId.Value, cancellationToken);
                return sharedPost != null;
            })
            .WithMessage("The shared post does not exist.");
    }
}