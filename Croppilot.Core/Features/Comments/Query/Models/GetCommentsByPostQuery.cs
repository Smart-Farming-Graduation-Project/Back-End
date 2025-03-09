using Croppilot.Core.Features.Comments.Query.Result;

namespace Croppilot.Core.Features.Comments.Query.Models;

public class GetCommentsByPostQuery : IRequest<Response<List<CommentResponse>>>
{
    public int PostId { get; set; }
}