using Croppilot.Core.Features.Rovers.Query.Result;

namespace Croppilot.Core.Features.Rovers.Query.Models;

public class GetAllRoversQuery : IRequest<Response<List<GetRoverResponse>>>
{
    // No parameters needed for getting all rovers
} 