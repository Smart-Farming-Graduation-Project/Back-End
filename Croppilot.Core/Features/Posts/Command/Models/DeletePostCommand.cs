namespace Croppilot.Core.Features.Posts.Command.Models;

public class DeletePostCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}