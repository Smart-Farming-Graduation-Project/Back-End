using Croppilot.Core.Features.Posts.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Posts.Command.Handlers;

public class PostCommandHandler(
    IPostService postService,
    IHttpContextAccessor contextAccessor) :
    ResponseHandler,
    IRequestHandler<AddPostCommand, Response<string>>,
    IRequestHandler<UpdatePostCommand, Response<string>>,
    IRequestHandler<DeletePostCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddPostCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        if (command.SharedPostId == 0)
            command.SharedPostId = null;

        var post = command.Adapt<Post>();
        post.UserId = userId;


        var result = await postService.AddPostAsync(post, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Post created successfully.")
            : BadRequest<string>("Failed to create post.");
    }

    public async Task<Response<string>> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var currentPost = await postService.GetPostByIdAsync(command.Id, cancellationToken);

        if (currentPost == null)
            return NotFound<string>("Post not found.");

        if (currentPost.UserId != userId)
            return Unauthorized<string>("You are not authorized to update this post.");

        if (command.SharedPostId == 0)
            command.SharedPostId = null;
        var post = command.Adapt<Post>();
        post.UserId = userId;
        var result = await postService.UpdatePostAsync(post, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Post updated successfully.")
            : BadRequest<string>("Failed to update post.");
    }

    public async Task<Response<string>> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var post = await postService.GetPostByIdAsync(command.Id, cancellationToken);

        if (post!.UserId != userId)
            return Unauthorized<string>("You are not authorized to delete this post.");

        var result = await postService.DeletePostAsync(command.Id, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Post deleted successfully.")
            : BadRequest<string>("Failed to delete post.");
    }
}