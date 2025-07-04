using Croppilot.Core.Features.Posts.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Posts.Command.Handlers;

public class PostCommandHandler(
    IPostService postService,
    IHttpContextAccessor contextAccessor,
    ICacheService cacheService,
    ICacheKeyGenerator cacheKeyGenerator) :
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
        
        if (result == OperationResult.Success)
        {
            // Invalidate global posts cache and user-specific caches since a new post was added
            await InvalidateGlobalPostsCacheAsync(cancellationToken);
            await InvalidateUserPostsCacheAsync(userId, cancellationToken);
            return Success<string>("Post created successfully.");
        }
        
        return BadRequest<string>("Failed to create post.");
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
        
        if (result == OperationResult.Success)
        {
            // Invalidate both individual post cache and global/user-specific caches
            await InvalidatePostCacheAsync(command.Id, userId, cancellationToken);
            return Success<string>("Post updated successfully.");
        }
        
        return BadRequest<string>("Failed to update post.");
    }

    public async Task<Response<string>> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var post = await postService.GetPostByIdAsync(command.Id, cancellationToken);

        if (post!.UserId != userId)
            return Unauthorized<string>("You are not authorized to delete this post.");

        var result = await postService.DeletePostAsync(command.Id, cancellationToken);
        
        if (result == OperationResult.Success)
        {
            // Invalidate both individual post cache and global/user-specific caches
            await InvalidatePostCacheAsync(command.Id, userId, cancellationToken);
            return Success<string>("Post deleted successfully.");
        }
        
        return BadRequest<string>("Failed to delete post.");
    }

    /// <summary>
    /// Invalidates global posts cache when posts are modified
    /// </summary>
    private async Task InvalidateGlobalPostsCacheAsync(CancellationToken cancellationToken)
    {
        try
        {
            // Invalidate collection cache for posts
            var collectionPattern = cacheKeyGenerator.GeneratePattern("global-posts");
            await cacheService.RemoveByPatternAsync(collectionPattern, cancellationToken);
        }
        catch (Exception ex)
        {
            // Log the error but don't fail the post operation
            // Logger would be needed here in a full implementation
        }
    }

    /// <summary>
    /// Invalidates user-specific posts cache for a user
    /// </summary>
    private async Task InvalidateUserPostsCacheAsync(string userId, CancellationToken cancellationToken)
    {
        try
        {
            // Invalidate user's posts cache
            var userPostsCacheKey = cacheKeyGenerator.GenerateUserKey(userId, "user-posts");
            await cacheService.RemoveAsync(userPostsCacheKey, cancellationToken);
        }
        catch (Exception ex)
        {
            // Log the error but don't fail the post operation
            // Logger would be needed here in a full implementation
        }
    }

    /// <summary>
    /// Invalidates individual post cache, global posts cache, and user-specific caches
    /// </summary>
    private async Task InvalidatePostCacheAsync(int postId, string userId, CancellationToken cancellationToken)
    {
        try
        {
            // Invalidate individual post cache
            var postCacheKey = cacheKeyGenerator.GenerateKey("global-post", postId);
            await cacheService.RemoveAsync(postCacheKey, cancellationToken);
            
            // Invalidate global posts cache
            await InvalidateGlobalPostsCacheAsync(cancellationToken);
            
            // Invalidate user's posts cache
            await InvalidateUserPostsCacheAsync(userId, cancellationToken);
        }
        catch (Exception ex)
        {
            // Log the error but don't fail the post operation
            // Logger would be needed here in a full implementation
        }
    }
}