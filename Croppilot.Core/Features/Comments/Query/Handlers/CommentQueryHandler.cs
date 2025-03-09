using Croppilot.Core.Features.Comments.Query.Models;
using Croppilot.Core.Features.Comments.Query.Result;

namespace Croppilot.Core.Features.Comments.Query.Handlers;

public class CommentQueryHandler(
    ICommentService commentService) : ResponseHandler,
    IRequestHandler<GetCommentsByPostQuery, Response<List<CommentResponse>>>,
    IRequestHandler<GetCommentByIdQuery, Response<CommentResponse>>
{
    public async Task<Response<List<CommentResponse>>> Handle(GetCommentsByPostQuery request, CancellationToken cancellationToken)
    {
        var comments = await commentService.GetCommentsByPostIdAsync(request.PostId, cancellationToken);
        if (comments.Count == 0)
            return NotFound<List<CommentResponse>>("No comments found for this post.");

        var response = comments.Select(c => new CommentResponse
        {
            Id = c.Id,
            PostId = c.PostId,
            UserId = c.UserId,
            Content = c.Content,
            VoteCount = c.VoteCount,
            ParentCommentId = c.ParentCommentId,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        }).ToList();

        return Success(response);
    }

    public async Task<Response<CommentResponse>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await commentService.GetCommentByIdAsync(request.Id, cancellationToken);
        if (comment == null)
            return NotFound<CommentResponse>("Comment not found.");

        var response = new CommentResponse
        {
            Id = comment.Id,
            PostId = comment.PostId,
            UserId = comment.UserId,
            Content = comment.Content,
            VoteCount = comment.VoteCount,
            ParentCommentId = comment.ParentCommentId,
            CreatedAt = comment.CreatedAt,
            UpdatedAt = comment.UpdatedAt
        };

        return Success(response);
    }
}