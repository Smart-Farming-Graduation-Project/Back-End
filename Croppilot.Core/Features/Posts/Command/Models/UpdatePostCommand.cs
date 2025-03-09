namespace Croppilot.Core.Features.Posts.Command.Models;

public class UpdatePostCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int? SharedPostId { get; set; }
}