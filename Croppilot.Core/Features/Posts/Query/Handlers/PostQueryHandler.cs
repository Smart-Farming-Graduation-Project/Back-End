using Croppilot.Core.Features.Posts.Query.Models;
using Croppilot.Core.Features.Posts.Query.Result;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Posts.Query.Handlers;

public class PostQueryHandler(
    IPostService postService,
    IUserVoteService userVoteService,
    ICacheService cacheService,
    ICacheKeyGenerator cacheKeyGenerator,
    IHttpContextAccessor httpContextAccessor) : ResponseHandler,
    IRequestHandler<GetPostsQuery, Response<List<GetAllPostsResponse>>>,
    IRequestHandler<GetPostByIdQuery, Response<GetPostByIdResponse>>,
    IRequestHandler<GetPostsByUserIdQuery, Response<List<GetPostsByUserIdResponse>>>
{
    public async Task<Response<List<GetAllPostsResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        // Step 1: Get or cache global post data (without user-specific data)
        var globalPosts = await GetOrCacheGlobalPostsAsync(cancellationToken);
        
        // Step 2: Get user-specific vote data
        var userId = GetCurrentUserId();
        var postIds = globalPosts.Select(p => p.Id).ToList();
        var userVotes = await userVoteService.GetUserVotesAsync(userId, postIds, cancellationToken);
        
        // Step 3: Merge global data with user-specific data
        var finalPosts = globalPosts.Select(global => global.Adapt<GetAllPostsResponse>() with
        {
            UserVoteStatus = userVotes.GetValueOrDefault(global.Id, 0)
        }).ToList();
        
        var result = Success(finalPosts);
        result.Meta = new Dictionary<string, object> { { "count", finalPosts.Count } };

        return result;
    }

    public async Task<Response<GetPostByIdResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        // Step 1: Get or cache global post data (without user-specific data)
        var globalPost = await GetOrCacheGlobalPostByIdAsync(request.Id, cancellationToken);
        
        if (globalPost is null)
            return NotFound<GetPostByIdResponse>("Post not found.");
        
        // Step 2: Get user-specific vote data
        var userId = GetCurrentUserId();
        var userVoteStatus = await userVoteService.GetUserVoteAsync(userId, request.Id, cancellationToken);
        
        // Step 3: Merge global data with user-specific data
        var finalPost = globalPost.Adapt<GetPostByIdResponse>() with
        {
            UserVoteStatus = userVoteStatus
        };

        return Success(finalPost);
    }

    public async Task<Response<List<GetPostsByUserIdResponse>>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        // Step 1: Get or cache global post data for specific user (without user-specific data)
        var globalPosts = await GetOrCacheGlobalPostsByUserIdAsync(request.UserId, cancellationToken);
        
        if (globalPosts.Count == 0)
            return NotFound<List<GetPostsByUserIdResponse>>("No posts found for this user.");
        
        // Step 2: Get user-specific vote data
        var currentUserId = GetCurrentUserId();
        var postIds = globalPosts.Select(p => p.Id).ToList();
        var userVotes = await userVoteService.GetUserVotesAsync(currentUserId, postIds, cancellationToken);
        
        // Step 3: Merge global data with user-specific data
        var finalPosts = globalPosts.Select(global => global.Adapt<GetPostsByUserIdResponse>() with
        {
            UserVoteStatus = userVotes.GetValueOrDefault(global.Id, 0)
        }).ToList();

        var result = Success(finalPosts);
        result.Meta = new Dictionary<string, object> { { "count", finalPosts.Count } };

        return result;
    }

    private async Task<List<GlobalPostResponse>> GetOrCacheGlobalPostsAsync(CancellationToken cancellationToken)
    {
        var cacheKey = cacheKeyGenerator.GenerateCollectionKey("global-posts");
        
        return await cacheService.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                var posts = await postService.GetAllPostsAsync(cancellationToken);
                return posts.Adapt<List<GlobalPostResponse>>();
            },
            TimeSpan.FromMinutes(30), // Cache global posts for 30 minutes
            cancellationToken);
    }

    private async Task<GlobalPostResponse?> GetOrCacheGlobalPostByIdAsync(int postId, CancellationToken cancellationToken)
    {
        var cacheKey = cacheKeyGenerator.GenerateKey("global-post", postId);
        
        return await cacheService.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                var post = await postService.GetPostByIdAsync(postId, cancellationToken);
                return post?.Adapt<GlobalPostResponse>();
            },
            TimeSpan.FromHours(1), // Cache individual posts for 1 hour
            cancellationToken);
    }

    private async Task<List<GlobalPostResponse>> GetOrCacheGlobalPostsByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "user-posts");
        
        return await cacheService.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                var posts = await postService.GetPostsByUserIdAsync(userId, cancellationToken);
                return posts.Adapt<List<GlobalPostResponse>>();
            },
            TimeSpan.FromMinutes(20), // Cache user's posts for 20 minutes
            cancellationToken);
    }

    private string GetCurrentUserId()
    {
        return httpContextAccessor?.HttpContext?.User.GetUserId() ?? string.Empty;
    }
}