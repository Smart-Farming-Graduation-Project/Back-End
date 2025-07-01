using Croppilot.Core.Features.ChatBot.Query.Models;
using Croppilot.Core.Features.ChatBot.Query.Result;
using Croppilot.Infrastructure.Extensions;
using Croppilot.Services.Abstract.AiSerives;

namespace Croppilot.Core.Features.ChatBot.Query.Handlers
{
	public class ChatHistoryQuery(IChatService chatService, IHttpContextAccessor httpContextAccessor)
		: ResponseHandler, IRequestHandler<GetChatHistory, Response<List<GetChatHistoryResult>>>,
		  IRequestHandler<GetChatHistoryByUserId, Response<List<GetChatHistoryResult>>>
	{
		public async Task<Response<List<GetChatHistoryResult>>> Handle(GetChatHistory request, CancellationToken cancellationToken)
		{
			var response = await chatService.GetChatHistoryAsync();
			if (response is null)
				return NotFound<List<GetChatHistoryResult>>("No Chat History already");

			var chatsResults = response.Select(x => new GetChatHistoryResult()
			{
				Id = x.Id,
				UserMessage = x.UserMessage,
				BotResponse = x.BotResponse,
				Timestamp = x.Timestamp
			}).ToList();

			var result = Success(chatsResults);
			result.Meta = new Dictionary<string, object>
		   {
			   { "count", chatsResults.Count }
		   };

			return result;
		}

		public async Task<Response<List<GetChatHistoryResult>>> Handle(GetChatHistoryByUserId request, CancellationToken cancellationToken)
		{
			var userId = httpContextAccessor?.HttpContext?.User.GetUserId();
			if (string.IsNullOrEmpty(userId))
				return NotFound<List<GetChatHistoryResult>>("User not found");
			var response = await chatService.GetChatHistoriesAsync(userId, request.Limit, request.StartDate, request.EndDate);
			if (response is null)
				return NotFound<List<GetChatHistoryResult>>("No Chat History found for this user");
			var chatsResults = response.Select(x => new GetChatHistoryResult()
			{
				Id = x.Id,
				UserMessage = x.UserMessage,
				BotResponse = x.BotResponse,
				Timestamp = x.Timestamp
			}).ToList();
			var result = Success(chatsResults);
			result.Meta = new Dictionary<string, object>
			{
			   { "count", chatsResults.Count }
			};
			return result;
		}
	}
}
