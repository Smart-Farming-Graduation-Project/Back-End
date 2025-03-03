namespace Croppilot.Core.Features.ChatBot.Command.Models
{
    public class MessageRequestModel : IRequest<Response<string>>
    {
        public string Prompt { get; set; }
    }
}
