using Croppilot.Core.Features.ChatBot.Query.Result;

namespace Croppilot.Core.Features.ChatBot.Query.Models
{
    public class GetChatHistory : IRequest<Response<List<GetChatHistoryResult>>>
    {
    }
}
