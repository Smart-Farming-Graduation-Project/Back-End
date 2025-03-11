using Croppilot.Infrastructure.Repositories.Interfaces;
using Hangfire;

namespace Croppilot.Services.Services
{
    public class VoteService(
        IVoteRepository voteRepository,
        IPostRepository postRepository,
        ICommentRepository commentRepository)
        : IVoteService
    {
        public async Task<OperationResult> AddOrUpdateVoteAsync(Vote vote,
            CancellationToken cancellationToken = default)
        {
            // Retrieve an existing vote by the same user on the same target.
            var existingVote =
                await voteRepository.GetVoteByUserAndTargetAsync(vote.UserId, vote.TargetId, vote.TargetType,
                    cancellationToken);
            int delta;
            if (existingVote != null)
            {
                // If the vote is the same, nothing to update.
                if (existingVote.VoteType == vote.VoteType)
                {
                    return OperationResult.Success;
                }

                // Compute the difference. For example, changing from +1 to -1 gives delta = -2.
                delta = vote.VoteType - existingVote.VoteType;
                existingVote.VoteType = vote.VoteType;
                await voteRepository.UpdateAsync(existingVote, cancellationToken);
            }
            else
            {
                // New vote: delta is just the vote value (1 or -1).
                delta = vote.VoteType;
                await voteRepository.AddAsync(vote, cancellationToken);
            }

            // Update the vote count on the target (post or comment) incrementally.
            BackgroundJob.Enqueue(() =>
                UpdateTargetVoteCountAsync(vote.TargetType, vote.TargetId, delta));

            return OperationResult.Success;
        }

        public async Task<OperationResult> DeleteVoteAsync(string userId, int targetId, string targetType,
            CancellationToken cancellationToken = default)
        {
            var existingVote =
                await voteRepository.GetVoteByUserAndTargetAsync(userId, targetId, targetType, cancellationToken);
            if (existingVote == null)
                return OperationResult.Failure;
            // Removing the vote means subtracting its vote value from the total.
            var delta = -existingVote.VoteType;
            await voteRepository.DeleteAsync(existingVote, cancellationToken);

            BackgroundJob.Enqueue(() => UpdateTargetVoteCountAsync(targetType, targetId, delta));
            return OperationResult.Success;
        }

        // Helper method to incrementally update the target's vote count.
        public async Task UpdateTargetVoteCountAsync(string targetType, int targetId, int delta)
        {
            targetType = targetType.ToLower();
            switch (targetType)
            {
                case "post":
                {
                    var post = await postRepository.GetAsync(p => p.Id == targetId);
                    if (post != null)
                    {
                        post.VoteCount += delta;
                        await postRepository.UpdateAsync(post);
                    }

                    break;
                }
                case "comment":
                {
                    var comment =
                        await commentRepository.GetAsync(c => c.Id == targetId);
                    if (comment != null)
                    {
                        comment.VoteCount += delta;
                        await commentRepository.UpdateAsync(comment);
                    }

                    break;
                }
            }
        }
    }
}