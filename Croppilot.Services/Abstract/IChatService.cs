namespace Croppilot.Services.Abstract
{
    public interface IChatService
    {
        Task<string> GetChatResponseAsync(string userMessage);
        Task<List<ChatHistory>> GetChatHistoryAsync();
    }
}
