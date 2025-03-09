namespace Croppilot.Core.Features.Comments.Query.Result;

public class CommentResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public int VoteCount { get; set; }
    public int? ParentCommentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}