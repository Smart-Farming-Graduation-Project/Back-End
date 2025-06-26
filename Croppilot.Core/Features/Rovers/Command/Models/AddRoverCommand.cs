namespace Croppilot.Core.Features.Rovers.Command.Models;

public class AddRoverCommand : IRequest<Response<string>>
{
    public string RoverId { get; set; }
    public string UserName { get; set; }
} 