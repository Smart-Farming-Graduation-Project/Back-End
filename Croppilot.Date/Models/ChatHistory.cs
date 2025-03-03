﻿namespace Croppilot.Date.Models
{
    public class ChatHistory
    {
        public int Id { get; set; }
        public string UserMessage { get; set; } = string.Empty;
        public string BotResponse { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
