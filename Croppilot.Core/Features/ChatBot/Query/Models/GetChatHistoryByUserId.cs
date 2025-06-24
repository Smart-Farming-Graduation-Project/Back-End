using Croppilot.Core.Features.ChatBot.Query.Result;

namespace Croppilot.Core.Features.ChatBot.Query.Models
{
	public class GetChatHistoryByUserId : IRequest<Response<List<GetChatHistoryResult>>>
	{
		public int? Limit { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
