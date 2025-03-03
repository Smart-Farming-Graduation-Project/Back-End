using Croppilot.Core.Features.ChatBot.Query.Models;
using Croppilot.Core.Features.ChatBot.Query.Result;

namespace Croppilot.Core.Features.ChatBot.Query.Handlers
{
    public class ChatHistoryQuery(IChatService chatService)
        : ResponseHandler, IRequestHandler<GetChatHistory, Response<List<GetChatHistoryResult>>>
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
    }
}
