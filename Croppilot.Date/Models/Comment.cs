namespace Croppilot.Date.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string UserId { get; set; }
    public int? ParentCommentId { get; set; }
    public string Content { get; set; }
    public int VoteCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;

    // Navigation properties
    public Post Post { get; set; }
    public ApplicationUser User { get; set; }
    public Comment ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; }
}