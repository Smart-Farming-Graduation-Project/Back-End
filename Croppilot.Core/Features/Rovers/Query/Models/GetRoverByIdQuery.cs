using Croppilot.Core.Features.Rovers.Query.Result;

namespace Croppilot.Core.Features.Rovers.Query.Models;

public class GetRoverByIdQuery : IRequest<Response<GetRoverResponse>>
{
    public string RoverId { get; set; }
} 