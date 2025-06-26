using Croppilot.Date.Identity;

namespace Croppilot.Date.Models;

public class Rover
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ApplicationUser User { get; set; }
} 