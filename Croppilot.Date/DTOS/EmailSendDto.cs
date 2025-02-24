namespace Croppilot.Date.DTOS
{
    public class EmailSendDto(
        string to,
        string subject,
        string? url,
        string userName,
        long templateId,
        Dictionary<string, object>? variables = null)
    {
        public string To { get; set; } = to;
        public string Subject { get; set; } = subject;
        public string? Url { get; set; } = url;
        public string UserName { get; set; } = userName;
        public long TemplateId { get; set; } = templateId;
        public Dictionary<string, object> Variables { get; set; } = variables ?? new Dictionary<string, object>();
    }
}
