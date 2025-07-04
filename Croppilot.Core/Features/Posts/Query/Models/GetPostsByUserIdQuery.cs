using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Features.Posts.Query.Models;

public class GetPostsByUserIdQuery : IRequest<Response<List<GetPostsByUserIdResponse>>>
{
    public string UserId { get; set; }
} 