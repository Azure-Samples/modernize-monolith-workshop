using Azure.AI.Inference;
using Azure;
using eShopLite.Store.Models;
using System.Collections.Concurrent;
using System.Text.Json;

namespace eShopLite.Store.Services
{
    public class ChatbotService : IChatbotService
    {
        private readonly ChatCompletionsClient? _chatClient;
        private readonly IProductApiClient _productApiClient;
        private readonly ILogger<ChatbotService> _logger;
        private readonly ConcurrentDictionary<string, ChatSession> _sessions = new();
        private readonly bool _isAiEnabled;

        private const string MODEL_NAME = "gpt-4o-mini";
        private const float TEMPERATURE = 0.7f;
        private const int MAX_TOKENS = 500;
        private const int MAX_HISTORY_MESSAGES = 10;

        public ChatbotService(
            ChatCompletionsClient? chatClient,
            IProductApiClient productApiClient,
            ILogger<ChatbotService> logger)
        {
            _chatClient = chatClient;
            _productApiClient = productApiClient ?? throw new ArgumentNullException(nameof(productApiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _isAiEnabled = _chatClient != null;

            if (!_isAiEnabled)
            {
                _logger.LogWarning("ChatCompletionsClient is not available. Running in fallback mode.");
            }
        }

        public async Task<ChatResponse> SendMessageAsync(ChatRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Message))
                {
                    return new ChatResponse
                    {
                        Message = "Please provide a message.",
                        SessionId = request.SessionId,
                        IsSuccessful = false,
                        ErrorMessage = "Empty message"
                    };
                }

                var sessionId = request.SessionId ?? Guid.NewGuid().ToString();
                var session = GetOrCreateSession(sessionId);

                // Add user message to session
                var userMessage = new ChatMessage
                {
                    Content = request.Message,
                    IsUser = true,
                    Timestamp = DateTime.UtcNow
                };
                session.Messages.Add(userMessage);
                session.LastActivity = DateTime.UtcNow;

                string botResponse;

                if (_isAiEnabled && _chatClient != null)
                {
                    botResponse = await GetAiResponseAsync(request.Message, session);
                }
                else
                {
                    botResponse = await GetFallbackResponseAsync(request.Message);
                }

                // Add bot response to session
                var botMessage = new ChatMessage
                {
                    Content = botResponse,
                    IsUser = false,
                    Timestamp = DateTime.UtcNow
                };
                session.Messages.Add(botMessage);

                // Keep only last 10 messages for memory management
                if (session.Messages.Count > MAX_HISTORY_MESSAGES)
                {
                    session.Messages = session.Messages
                        .Skip(session.Messages.Count - MAX_HISTORY_MESSAGES)
                        .ToList();
                }

                return new ChatResponse
                {
                    Message = botResponse,
                    SessionId = sessionId,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing chat message: {Message}", request.Message);
                return new ChatResponse
                {
                    Message = "I'm sorry, I'm having trouble processing your request right now. Please try again later.",
                    SessionId = request.SessionId,
                    IsSuccessful = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(string sessionId)
        {
            await Task.CompletedTask;
            
            if (_sessions.TryGetValue(sessionId, out var session))
            {
                return session.Messages;
            }

            return Enumerable.Empty<ChatMessage>();
        }

        public async Task ClearChatHistoryAsync(string sessionId)
        {
            await Task.CompletedTask;
            
            if (_sessions.TryGetValue(sessionId, out var session))
            {
                session.Messages.Clear();
                session.LastActivity = DateTime.UtcNow;
            }
        }

        private ChatSession GetOrCreateSession(string sessionId)
        {
            return _sessions.GetOrAdd(sessionId, _ => new ChatSession { Id = sessionId });
        }

        private async Task<string> GetAiResponseAsync(string userMessage, ChatSession session)
        {
            try
            {
                // Get product context for AI awareness
                var products = await _productApiClient.GetProductsAsync();
                var productContext = await BuildProductContextAsync(products);

                // Build conversation history for context
                var messages = new List<ChatRequestMessage>
                {
                    new ChatRequestSystemMessage($@"You are a helpful assistant for eShopLite, an outdoor gear and sporting goods store. 
You help customers find products, answer questions about outdoor activities, and provide store information.

Available Products Context:
{productContext}

Guidelines:
- Be friendly, knowledgeable, and helpful
- Focus on outdoor gear, camping, hiking, and sporting goods
- Recommend specific products when relevant
- Keep responses concise and under 500 characters
- If asked about products not in our catalog, suggest alternatives or related items
- For store locations, mention we have multiple locations across different states")
                };

                // Add recent conversation history (last 5 exchanges)
                var recentMessages = session.Messages
                    .TakeLast(8) // Last 4 exchanges (user + bot)
                    .ToList();

                foreach (var msg in recentMessages)
                {
                    if (msg.IsUser)
                    {
                        messages.Add(new ChatRequestUserMessage(msg.Content));
                    }
                    else
                    {
                        messages.Add(new ChatRequestAssistantMessage(msg.Content));
                    }
                }

                // Add current user message
                messages.Add(new ChatRequestUserMessage(userMessage));

                var requestOptions = new ChatCompletionsOptions()
                {
                    Messages = messages,
                    Model = MODEL_NAME,
                    Temperature = TEMPERATURE,
                    MaxTokens = MAX_TOKENS
                };

                var response = await _chatClient!.CompleteAsync(requestOptions);
                return response.Value.Content ?? "I'm sorry, I couldn't generate a response.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting AI response");
                return await GetFallbackResponseAsync(userMessage);
            }
        }

        private async Task<string> BuildProductContextAsync(IEnumerable<Product> products)
        {
            try
            {
                var productList = products.Take(20).Select(p => 
                    $"- {p.Name} (${p.Price:F2}) - {p.Description}").ToArray();
                
                return string.Join("\n", productList);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error building product context");
                return "Various outdoor gear and sporting goods available";
            }
        }

        private async Task<string> GetFallbackResponseAsync(string userMessage)
        {
            await Task.CompletedTask;

            var lowerMessage = userMessage.ToLowerInvariant();

            // Pattern matching for common queries
            return lowerMessage switch
            {
                var msg when msg.Contains("product") || msg.Contains("gear") || msg.Contains("equipment") =>
                    "We offer a wide range of outdoor gear including hiking equipment, camping gear, and sporting goods. You can browse our products on the Products page to see what's available!",

                var msg when msg.Contains("store") || msg.Contains("location") || msg.Contains("address") =>
                    "We have multiple store locations across different states including Washington, Colorado, Texas, and Oregon. Check out our Stores page for specific locations and hours!",

                var msg when msg.Contains("hour") || msg.Contains("open") || msg.Contains("close") =>
                    "Our store hours vary by location. Most stores are open Monday through Saturday from 8AM-9PM and Sundays from 9AM-6PM. Check the Stores page for specific hours at each location.",

                var msg when msg.Contains("help") || msg.Contains("support") =>
                    "I'm here to help you with information about our outdoor gear, store locations, and general questions. Feel free to ask about specific products or visit our Products and Stores pages!",

                var msg when msg.Contains("price") || msg.Contains("cost") || msg.Contains("$") =>
                    "Our products are competitively priced for quality outdoor gear. You can see current pricing on our Products page, and we often have seasonal sales and promotions!",

                var msg when msg.Contains("camping") || msg.Contains("hiking") || msg.Contains("outdoor") =>
                    "We're passionate about outdoor adventures! We carry everything you need for camping, hiking, and outdoor activities. From tents and sleeping bags to hiking boots and navigation gear.",

                var msg when msg.Contains("thank") =>
                    "You're welcome! I'm happy to help with any questions about our outdoor gear and store information.",

                var msg when msg.Contains("bye") || msg.Contains("goodbye") =>
                    "Thanks for visiting eShopLite! Have a great day and enjoy your outdoor adventures!",

                _ => "Thanks for your question! I can help you with information about our outdoor gear, store locations, and hours. You can also browse our Products and Stores pages for more details. What would you like to know?"
            };
        }
    }
}