using Microsoft.Extensions.Logging;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class UserVoteService(
    ICacheService cacheService,
    ICacheKeyGenerator cacheKeyGenerator,
    IVoteRepository voteRepository,
    ILogger<UserVoteService> logger)
    : IUserVoteService
{
    private const int CACHE_EXPIRATION_MINUTES = 30;

    public async Task<Dictionary<int, int>> GetUserVotesAsync(string userId, List<int> postIds, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId) || !postIds.Any())
        {
            return postIds.ToDictionary(id => id, _ => 0);
        }

        try
        {
            var userPostVotes = await GetUserPostVotesAsync(userId, cancellationToken);
            
            // Convert the cached votes to the requested dictionary format
            return postIds.ToDictionary(
                id => id, 
                id => userPostVotes.GetValueOrDefault(id, 0)
            );
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting user votes for user {UserId}", userId);
            return postIds.ToDictionary(id => id, _ => 0);
        }
    }

    public async Task<int> GetUserVoteAsync(string userId, int postId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId))
            return 0;

        try
        {
            var userPostVotes = await GetUserPostVotesAsync(userId, cancellationToken);
            return userPostVotes.GetValueOrDefault(postId, 0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting user vote for user {UserId}, post {PostId}", userId, postId);
            return 0;
        }
    }

    public async Task RefreshUserVotesAsync(string userId, List<int> postIds, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId))
            return;

        try
        {
            await RefreshUserPostVotesAsync(userId, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error refreshing user votes for user {UserId}", userId);
        }
    }

    public async Task InvalidateUserVotesAsync(string userId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId))
            return;

        try
        {
            var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "votes");
            await cacheService.RemoveAsync(cacheKey, cancellationToken);
            logger.LogDebug("Invalidated user votes cache for user {UserId}", userId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error invalidating user votes for user {UserId}", userId);
        }
    }

    /// <summary>
    /// Gets the dictionary of post votes that the user has made (from cache or database)
    /// </summary>
    private async Task<Dictionary<int, int>> GetUserPostVotesAsync(string userId, CancellationToken cancellationToken)
    {
        var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "votes");
        var cachedVotes = await cacheService.GetAsync<UserPostVotes>(cacheKey, cancellationToken);

        if (cachedVotes != null && IsValidCache(cachedVotes))
        {
            logger.LogDebug("Cache hit for user votes: {UserId}, {Count} votes", 
                userId, cachedVotes.PostVotes.Count);
            return cachedVotes.PostVotes;
        }

        // Cache miss or expired - refresh from database
        return await RefreshUserPostVotesAsync(userId, cancellationToken);
    }

    /// <summary>
    /// Refreshes the user's post votes from the database and caches them
    /// </summary>
    private async Task<Dictionary<int, int>> RefreshUserPostVotesAsync(string userId, CancellationToken cancellationToken)
    {
        // Get user's votes from database for posts only
        var votes = await voteRepository.GetAllAsync(
            filter: v => v.UserId == userId && v.TargetType == "post",
            cancellationToken: cancellationToken);
        
        // Convert to dictionary (PostId -> VoteType)
        var postVotes = votes.ToDictionary(v => v.TargetId, v => v.VoteType);

        // Cache the votes (only the votes, not all post data)
        var userPostVotes = new UserPostVotes(
            userId,
            postVotes,
            DateTime.UtcNow
        );

        var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "votes");
        var expiration = TimeSpan.FromMinutes(CACHE_EXPIRATION_MINUTES);
        await cacheService.SetAsync(cacheKey, userPostVotes, expiration, cancellationToken);

        logger.LogDebug("Refreshed user votes cache for user {UserId} with {Count} votes", 
            userId, postVotes.Count);

        return postVotes;
    }

    private static bool IsValidCache(UserPostVotes cachedVotes)
    {
        // Cache is valid for 30 minutes
        return DateTime.UtcNow - cachedVotes.LastUpdated < TimeSpan.FromMinutes(CACHE_EXPIRATION_MINUTES);
    }
} 