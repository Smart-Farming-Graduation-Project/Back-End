namespace Croppilot.Services.Abstract.AiSerives
{
	public interface IChatService
	{
		Task<string> GetChatResponseAsync(string userMessage);
		Task<List<ChatHistory>> GetChatHistoryAsync();
		Task<List<ChatHistory>> GetChatHistoriesAsync(string userId, int? limit, DateTime? startDate = null, DateTime? endDate = null);
	}
}
