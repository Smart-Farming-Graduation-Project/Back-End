using Croppilot.Core.Features.Votes.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Votes.Command.Handlers;

public class VoteCommandHandler(
    IVoteService voteService,
    IHttpContextAccessor contextAccessor,
    IUserVoteService userVoteService,
    ICacheService cacheService,
    ICacheKeyGenerator cacheKeyGenerator) :
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
        
        if (result == OperationResult.Success)
        {
            // Invalidate user's vote cache since their vote changed
            await userVoteService.InvalidateUserVotesAsync(userId, cancellationToken);
            
            // If this is a post vote, also invalidate global post cache since vote count may have changed
            if (command.TargetType.ToLower() == "post")
            {
                await InvalidatePostCacheAsync(command.TargetId, cancellationToken);
            }
            
            return Success<string>("Vote recorded successfully.");
        }
        
        return BadRequest<string>("Failed to record vote.");
    }

    public async Task<Response<string>> Handle(DeleteVoteCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var result = await voteService.DeleteVoteAsync(userId, command.TargetId, command.TargetType.ToLower(), cancellationToken);
        
        if (result == OperationResult.Success)
        {
            // Invalidate user's vote cache since their vote was deleted
            await userVoteService.InvalidateUserVotesAsync(userId, cancellationToken);
            
            // If this is a post vote, also invalidate global post cache since vote count may have changed
            if (command.TargetType.ToLower() == "post")
            {
                await InvalidatePostCacheAsync(command.TargetId, cancellationToken);
            }
            
            return Success<string>("Vote deleted successfully.");
        }
        
        return BadRequest<string>("Failed to delete vote.");
    }

    /// <summary>
    /// Invalidates global post cache when post vote counts change
    /// </summary>
    private async Task InvalidatePostCacheAsync(int postId, CancellationToken cancellationToken)
    {
        try
        {
            // Invalidate individual post cache
            var postCacheKey = cacheKeyGenerator.GenerateKey("global-post", postId);
            await cacheService.RemoveAsync(postCacheKey, cancellationToken);
            
            // Invalidate collection cache for posts
            var collectionPattern = cacheKeyGenerator.GeneratePattern("global-posts");
            await cacheService.RemoveByPatternAsync(collectionPattern, cancellationToken);
        }
        catch (Exception ex)
        {
            // Log the error but don't fail the vote operation
            // Logger would be needed here in a full implementation
        }
    }
}