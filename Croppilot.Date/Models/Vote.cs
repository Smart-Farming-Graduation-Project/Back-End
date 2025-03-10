namespace Croppilot.Date.Models;

public class Vote
{
    public int Id { get; set; }
    public string UserId { get; set; }       
    public int TargetId { get; set; }
    public string TargetType { get; set; }     // "post" or "comment".
    public int VoteType { get; set; }          // +1 for upvote, -1 for downvote.
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property.
    public ApplicationUser User { get; set; }
}