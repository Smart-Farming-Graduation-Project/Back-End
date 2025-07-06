using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Features.Posts.Query.Models;

public class GetPostByIdQuery : IRequest<Response<GetPostByIdResponse>>
{
    public int Id { get; set; }
}