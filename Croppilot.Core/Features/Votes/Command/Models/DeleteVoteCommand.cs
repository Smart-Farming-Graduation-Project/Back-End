namespace Croppilot.Core.Features.Votes.Command.Models;

public class DeleteVoteCommand : IRequest<Response<string>>
{
    public int TargetId { get; set; }
    public string TargetType { get; set; }  // "post" or "comment"
}