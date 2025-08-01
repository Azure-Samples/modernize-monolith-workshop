using System.ComponentModel.DataAnnotations;

namespace eShopLite.Store.Models
{
    public class ChatMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        public bool IsUser { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class ChatRequest
    {
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public string? SessionId { get; set; }
    }

    public class ChatResponse
    {
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public string? SessionId { get; set; }
        
        public bool IsSuccessful { get; set; } = true;
        
        public string? ErrorMessage { get; set; }
    }

    public class ChatSession
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public List<ChatMessage> Messages { get; set; } = new();
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime LastActivity { get; set; } = DateTime.UtcNow;
    }
}