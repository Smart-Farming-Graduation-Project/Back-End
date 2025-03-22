using Azure;
using Azure.AI.OpenAI;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract.AiSerives;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace Croppilot.Services.Services.AIServises
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ChatClient _chatClient;
        public ChatService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            var endpoint = _configuration["OpenAI:Endpoint"];
            var key = _configuration["OpenAI:Key"];
            AzureKeyCredential credential = new AzureKeyCredential(key);
            AzureOpenAIClient azureClient = new(new Uri(endpoint), credential);
            _chatClient = azureClient.GetChatClient(_configuration["OpenAI:DeploymentName"]);
        }
        public async Task<string> GetChatResponseAsync(string userMessage)
        {
            string? systemMessage = _configuration["OpenAI:SystemMessage"];

            ChatCompletion completion = await _chatClient.CompleteChatAsync(
                new SystemChatMessage(systemMessage),
                new UserChatMessage("Hi ,can you help me"),
                new AssistantChatMessage("Yes of course, How i can mentor you today"),
                new UserChatMessage(userMessage));

            // Save the chat to the database
            var chatHistory = new ChatHistory
            {
                UserMessage = userMessage,
                BotResponse = completion.Content[0].Text,
                Timestamp = DateTime.UtcNow
            };
            await _unitOfWork.ChatRepository.AddAsync(chatHistory);
            return completion.Content[0].Text;
        }

        public Task<List<ChatHistory>> GetChatHistoryAsync()
        {
            return _unitOfWork.ChatRepository.GetAllAsync();
        }
    }
}
