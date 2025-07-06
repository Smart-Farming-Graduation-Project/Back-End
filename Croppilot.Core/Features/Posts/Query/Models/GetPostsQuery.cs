using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Features.Posts.Query.Models;

public class GetPostsQuery : IRequest<Response<List<GetAllPostsResponse>>>
{
}