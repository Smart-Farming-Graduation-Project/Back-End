namespace Croppilot.Core.Features.Comments.Command.Models;

public class UpdateCommentCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Content { get; set; }
}