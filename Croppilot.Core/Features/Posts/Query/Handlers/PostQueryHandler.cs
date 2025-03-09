using Croppilot.Core.Features.Posts.Query.Models;
using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Features.Posts.Query.Handlers;

public class PostQueryHandler(IPostService postService) : ResponseHandler,
    IRequestHandler<GetPostsQuery, Response<List<PostResponse>>>,
    IRequestHandler<GetPostByIdQuery, Response<PostResponse>>
{
    public async Task<Response<List<PostResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await postService.GetAllPostsAsync(cancellationToken);
        if (posts.Count == 0)
            return NotFound<List<PostResponse>>("No posts found.");

        var response = posts.Select(p => new PostResponse
        {
            Id = p.Id,
            UserId = p.UserId,
            Title = p.Title,
            Content = p.Content,
            VoteCount = p.VoteCount,
            SharedPostId = p.SharedPostId,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        }).ToList();

        return Success(response);
    }

    public async Task<Response<PostResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await postService.GetPostByIdAsync(request.Id, cancellationToken);
        if (post == null)
            return NotFound<PostResponse>("Post not found.");

        var response = post.Adapt<PostResponse>();
        return Success(response);
    }
}