namespace Croppilot.Date.Models;

public class Post
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int VoteCount { get; set; } = 0;
    public int? SharedPostId { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;

    public ApplicationUser User { get; set; }
    public Post SharedPost { get; set; }
    public ICollection<Post> Shares { get; set; }
}