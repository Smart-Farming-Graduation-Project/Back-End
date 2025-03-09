namespace Croppilot.Core.Features.Comments.Command.Models;

public class AddCommentCommand : IRequest<Response<string>>
{
    public int PostId { get; set; }
    public string UserId { get; set; }
    public int? ParentCommentId { get; set; }
    public string Content { get; set; }
}