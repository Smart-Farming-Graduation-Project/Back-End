using Croppilot.Core.Features.Rovers.Query.Result;

namespace Croppilot.Core.Features.Rovers.Query.Models;

public class GetUserRoversQuery : IRequest<Response<List<GetRoverResponse>>>
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
} 