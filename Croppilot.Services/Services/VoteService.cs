using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class VoteService(IVoteRepository voteRepository) : IVoteService
{
    public async Task<OperationResult> AddOrUpdateVoteAsync(Vote vote, CancellationToken cancellationToken = default)
    {
        var existingVote = await voteRepository.GetVoteByUserAndTargetAsync(vote.UserId, vote.TargetId, vote.TargetType, cancellationToken);
        if (existingVote != null)
        {
            // Update the vote value.
            existingVote.VoteType = vote.VoteType;
            await voteRepository.UpdateAsync(existingVote, cancellationToken);
        }
        else
        {
            // Add new vote.
            await voteRepository.AddAsync(vote, cancellationToken);
        }
        return OperationResult.Success;
    }

    public async Task<OperationResult> DeleteVoteAsync(string userId, int targetId, string targetType, CancellationToken cancellationToken = default)
    {
        var vote = await voteRepository.GetVoteByUserAndTargetAsync(userId, targetId, targetType, cancellationToken);
        if (vote == null)
            return OperationResult.Failure;

        await voteRepository.DeleteAsync(vote, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<Vote?> GetVoteAsync(string userId, int targetId, string targetType, CancellationToken cancellationToken = default)
    {
        return await voteRepository.GetVoteByUserAndTargetAsync(userId, targetId, targetType, cancellationToken);
    }
}