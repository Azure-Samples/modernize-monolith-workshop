using eShopLite.Store.Models;

namespace eShopLite.Store.Services
{
    public interface IChatbotService
    {
        Task<ChatResponse> SendMessageAsync(ChatRequest request);
        Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(string sessionId);
        Task ClearChatHistoryAsync(string sessionId);
    }
}