namespace Croppilot.Core.Features.ChatBot.Query.Result
{
    public class GetChatHistoryResult
    {
        public int Id { get; set; }
        public string UserMessage { get; set; }
        public string BotResponse { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
