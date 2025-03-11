using Croppilot.Core.Features.Votes.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Votes.Command.Handlers;

public class VoteCommandHandler(
    IVoteService voteService,
    IHttpContextAccessor contextAccessor) :
    ResponseHandler,
    IRequestHandler<AddOrUpdateVoteCommand, Response<string>>,
    IRequestHandler<DeleteVoteCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddOrUpdateVoteCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
            
        var vote = new Vote
        {
            UserId = userId,
            TargetId = command.TargetId,
            TargetType = command.TargetType.ToLower(), // standardize value.
            VoteType = command.VoteType
        };

        var result = await voteService.AddOrUpdateVoteAsync(vote, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Vote recorded successfully.")
            : BadRequest<string>("Failed to record vote.");
    }

    public async Task<Response<string>> Handle(DeleteVoteCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var result = await voteService.DeleteVoteAsync(userId, command.TargetId, command.TargetType.ToLower(), cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Vote deleted successfully.")
            : BadRequest<string>("Failed to delete vote.");
    }
}