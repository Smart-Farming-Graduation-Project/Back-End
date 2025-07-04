using Croppilot.Core.Features.Posts.Query.Models;
using Croppilot.Core.Features.Posts.Query.Result;
using Croppilot.Infrastructure.Extensions;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Core.Features.Posts.Query.Handlers;

public class PostQueryHandler(
    IPostService postService,
    IHttpContextAccessor contextAccessor,
    IVoteRepository voteRepository) : ResponseHandler,
    IRequestHandler<GetPostsQuery, Response<List<PostResponse>>>,
    IRequestHandler<GetPostByIdQuery, Response<PostResponse>>,
    IRequestHandler<GetPostsByUserIdQuery, Response<List<PostResponse>>>
{
    public async Task<Response<List<PostResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await postService.GetAllPostsAsync(cancellationToken);
        if (posts.Count == 0)
            return NotFound<List<PostResponse>>("No posts found.");

        // Get current user ID (null if not authenticated)
        var currentUserId = contextAccessor.HttpContext?.User.GetUserId();
        
        // Get user votes for all posts in one query to avoid N+1 queries
        Dictionary<int, int> userVotes = new();
        if (!string.IsNullOrEmpty(currentUserId))
        {
            var postIds = posts.Select(p => p.Id).ToList();
            var votes = await voteRepository.GetUserVotesForPostsAsync(currentUserId, postIds, cancellationToken);
            userVotes = votes.ToDictionary(v => v.TargetId, v => v.VoteType);
        }

        var response = posts.Select(p => new PostResponse
        {
            Id = p.Id,
            UserId = p.UserId,
            Title = p.Title,
            Content = p.Content,
            VoteCount = p.VoteCount,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            UserVoteStatus = userVotes.ContainsKey(p.Id) ? userVotes[p.Id] : 0
        }).ToList();

        return Success(response);
    }

    public async Task<Response<PostResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await postService.GetPostByIdAsync(request.Id, cancellationToken);
        if (post == null)
            return NotFound<PostResponse>("Post not found.");

        // Get current user ID (null if not authenticated)
        var currentUserId = contextAccessor.HttpContext?.User.GetUserId();
        var userVoteStatus = 0;
        
        // Get user's vote for this specific post
        if (!string.IsNullOrEmpty(currentUserId))
        {
            var vote = await voteRepository.GetVoteByUserAndTargetAsync(currentUserId, request.Id, "post", cancellationToken);
            userVoteStatus = vote?.VoteType ?? 0;
        }

        var response = new PostResponse
        {
            Id = post.Id,
            UserId = post.UserId,
            Title = post.Title,
            Content = post.Content,
            VoteCount = post.VoteCount,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
            UserVoteStatus = userVoteStatus
        };

        return Success(response);
    }

    public async Task<Response<List<PostResponse>>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var posts = await postService.GetPostsByUserIdAsync(request.UserId, cancellationToken);
        if (posts.Count == 0)
            return NotFound<List<PostResponse>>("No posts found for this user.");

        // Get current user ID (null if not authenticated)
        var currentUserId = contextAccessor.HttpContext?.User.GetUserId();
        
        // Get user votes for all posts in one query to avoid N+1 queries
        Dictionary<int, int> userVotes = new();
        if (!string.IsNullOrEmpty(currentUserId))
        {
            var postIds = posts.Select(p => p.Id).ToList();
            var votes = await voteRepository.GetUserVotesForPostsAsync(currentUserId, postIds, cancellationToken);
            userVotes = votes.ToDictionary(v => v.TargetId, v => v.VoteType);
        }

        var response = posts.Select(p => new PostResponse
        {
            Id = p.Id,
            UserId = p.UserId,
            Title = p.Title,
            Content = p.Content,
            VoteCount = p.VoteCount,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            UserVoteStatus = userVotes.ContainsKey(p.Id) ? userVotes[p.Id] : 0
        }).ToList();

        return Success(response);
    }
}