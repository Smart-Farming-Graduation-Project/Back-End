using Croppilot.Core.Features.ChatBot.Command.Models;

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
