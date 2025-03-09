namespace Croppilot.Core.Features.Posts.Query.Result;

public class PostResponse
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int VoteCount { get; set; }
    public int? SharedPostId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}