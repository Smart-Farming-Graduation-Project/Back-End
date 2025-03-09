using Croppilot.Core.Features.Comments.Query.Result;

namespace Croppilot.Core.Features.Comments.Query.Models;

public class GetCommentByIdQuery : IRequest<Response<CommentResponse>>
{
    public int Id { get; set; }
}