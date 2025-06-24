using System.ComponentModel.DataAnnotations.Schema;

namespace Croppilot.Date.Models
{
	public class ChatHistory
	{
		public int Id { get; set; }
		public string UserMessage { get; set; } = string.Empty;
		public string BotResponse { get; set; } = string.Empty;
		public DateTime Timestamp { get; set; }
		//[Required(ErrorMessage = "User Id is required")]
		[ForeignKey(nameof(User.Id))]
		public string? UserId { get; set; }
		public ApplicationUser? User { get; set; }
	}
}
