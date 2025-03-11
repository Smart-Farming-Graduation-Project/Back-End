namespace Croppilot.Core.Features.Votes.Command.Models;

public class AddOrUpdateVoteCommand : IRequest<Response<string>>
{
    public int TargetId { get; set; }
    public string TargetType { get; set; }  // "post" or "comment"
    public int VoteType { get; set; }         // +1 or -1
}