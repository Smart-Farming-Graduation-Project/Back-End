namespace Croppilot.Core.Features.Comments.Command.Models;

public class DeleteCommentCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}