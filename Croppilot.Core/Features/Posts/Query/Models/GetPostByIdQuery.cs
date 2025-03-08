using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Features.Posts.Query.Models;

public class GetPostByIdQuery : IRequest<Response<PostResponse>>
{
    public int Id { get; set; }
}