namespace Croppilot.Core.Features.Notification.Models
{
    public class SmsRequest : IRequest<Response<string>>
    {
        public string To { get; set; }
        public string Message { get; set; }
    }
}
