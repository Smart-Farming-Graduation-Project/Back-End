using Croppilot.Core.Features.ChatBot.Command.Models;
using Croppilot.Services.Abstract.AiSerives;

namespace Croppilot.Core.Features.ChatBot.Command.Handlers
{
    class GetChatResponseHandler(IChatService chatService) : ResponseHandler,
        IRequestHandler<MessageRequestModel, Response<string>>
    {
        public async Task<Response<string>> Handle(MessageRequestModel request, CancellationToken cancellationToken)
        {
            var response = await chatService.GetChatResponseAsync(request.Prompt);
            return Success<string>(response);
        }
    }
}
