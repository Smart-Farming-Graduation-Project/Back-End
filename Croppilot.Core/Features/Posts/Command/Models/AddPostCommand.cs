namespace Croppilot.Core.Features.Posts.Command.Models;

public class AddPostCommand : IRequest<Response<string>>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int? SharedPostId { get; set; }
}