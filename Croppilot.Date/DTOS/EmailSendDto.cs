namespace Croppilot.Date.DTOS
{
    public class EmailSendDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
        public string? Url { get; set; }
        public string? UserName { get; set; }
        public long TemplateId { get; set; }

        public EmailSendDto(string to, string subject, string url, string userName, long templateId)
        {
            To = to;
            Subject = subject;
            Url = url;
            UserName = userName;
            TemplateId = templateId;
        }

        public EmailSendDto(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }


}

//after make all templetes this is final version
//    public class EmailSendDto(string to, string subject, string body, string url, string userName, int templateId)
// {
//     public string To { get; set; } = to;
//     public string Subject { get; set; } = subject;
//     public string? Body { get; set; } = body;
//     public string? Url { get; set; } = url;
//     public string? UserName { get; set; } = userName;
//     public int? TemplateId { get; set; } = templateId;
// }

