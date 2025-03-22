namespace Croppilot.Services.Abstract.AiSerives
{
    public interface IChatService
    {
        Task<string> GetChatResponseAsync(string userMessage);
        Task<List<ChatHistory>> GetChatHistoryAsync();
    }
}
