namespace Croppilot.Date.Models;

/// <summary>
/// Represents user-specific vote data for posts (only stores posts the user has actually voted on)
/// </summary>
public record UserPostVotes(
    string UserId,
    Dictionary<int, int> PostVotes, // PostId -> VoteType (1 for upvote, -1 for downvote)
    DateTime LastUpdated
);

/// <summary>
/// Represents a single post's vote status for a user
/// </summary>
public record PostVoteStatus(
    int PostId,
    int VoteType // 1 for upvote, 0 for no vote, -1 for downvote
); 