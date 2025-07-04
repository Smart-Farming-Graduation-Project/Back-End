using Croppilot.Core.Features.Posts.Query.Models;
using Croppilot.Core.Features.Posts.Query.Result;
using Croppilot.Infrastructure.Extensions;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Core.Features.Posts.Query.Handlers;

public class PostQueryHandler(
    IPostService postService,
    IHttpContextAccessor contextAccessor,
    IVoteRepository voteRepository,
    IUserVoteService userVoteService,
    ICacheService cacheService,
    ICacheKeyGenerator cacheKeyGenerator) : ResponseHandler,
    IRequestHandler<GetPostsQuery, Response<List<PostResponse>>>,
    IRequestHandler<GetPostByIdQuery, Response<PostResponse>>
{
    public async Task<Response<List<PostResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        // Step 1: Get or cache global post data (without user-specific data)
        var globalPosts = await GetOrCacheGlobalPostsAsync(cancellationToken);
        
        if (globalPosts.Count == 0)
            return NotFound<List<PostResponse>>("No posts found.");

        // Step 2: Get user-specific vote data
        var userId = GetCurrentUserId();
        var postIds = globalPosts.Select(p => p.Id).ToList();
        var userVotes = await userVoteService.GetUserVotesAsync(userId, postIds, cancellationToken);
        
        // Step 3: Merge global data with user-specific data
        var finalPosts = globalPosts.Select(global =>
        {
            var postResponse = global.Adapt<PostResponse>();
            postResponse.UserVoteStatus = userVotes.GetValueOrDefault(global.Id, 0);
            return postResponse;
        }).ToList();

        var result = Success(finalPosts);
        result.Meta = new Dictionary<string, object> { { "count", finalPosts.Count } };

        return result;
    }

    public async Task<Response<PostResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        // Step 1: Get or cache global post data (without user-specific data)
        var globalPost = await GetOrCacheGlobalPostByIdAsync(request.Id, cancellationToken);
        
        if (globalPost is null)
            return NotFound<PostResponse>("Post not found.");

        // Step 2: Get user-specific vote data
        var userId = GetCurrentUserId();
        var userVoteStatus = await userVoteService.GetUserVoteAsync(userId, request.Id, cancellationToken);
        
        // Step 3: Merge global data with user-specific data
        var finalPost = globalPost.Adapt<PostResponse>();
        finalPost.UserVoteStatus = userVoteStatus;

        return Success(finalPost);
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

    private async Task<GlobalPostByIdResponse?> GetOrCacheGlobalPostByIdAsync(int postId, CancellationToken cancellationToken)
    {
        var cacheKey = cacheKeyGenerator.GenerateKey("global-post", postId);
        
        return await cacheService.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                var post = await postService.GetPostByIdAsync(postId, cancellationToken);
                
                if (post is null) return null;
                
                return post.Adapt<GlobalPostByIdResponse>();
            },
            TimeSpan.FromHours(1), // Cache individual posts for 1 hour
            cancellationToken);
    }

    private string GetCurrentUserId()
    {
        return contextAccessor?.HttpContext?.User.GetUserId() ?? string.Empty;
    }
}