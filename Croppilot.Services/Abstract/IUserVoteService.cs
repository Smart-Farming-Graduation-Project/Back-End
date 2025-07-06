namespace Croppilot.Services.Abstract;

/// <summary>
/// Service for managing user-specific post votes cache
/// </summary>
public interface IUserVoteService
{
    /// <summary>
    /// Gets the vote status for multiple posts for a specific user
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="postIds">List of post IDs to check</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Dictionary with PostId -> VoteType mapping (1 for upvote, 0 for no vote, -1 for downvote)</returns>
    Task<Dictionary<int, int>> GetUserVotesAsync(string userId, List<int> postIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the vote status for a single post for a specific user
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="postId">Post ID to check</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Vote type (1 for upvote, 0 for no vote, -1 for downvote)</returns>
    Task<int> GetUserVoteAsync(string userId, int postId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the user's votes cache
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="postIds">List of post IDs to cache votes for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task RefreshUserVotesAsync(string userId, List<int> postIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invalidates the user's votes cache when vote changes occur
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task InvalidateUserVotesAsync(string userId, CancellationToken cancellationToken = default);
} 