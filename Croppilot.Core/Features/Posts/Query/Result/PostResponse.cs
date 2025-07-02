namespace Croppilot.Core.Features.Posts.Query.Result;

public class PostResponse
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int VoteCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int UserVoteStatus { get; set; } // 1 for upvote, 0 for no vote, -1 for downvote
}