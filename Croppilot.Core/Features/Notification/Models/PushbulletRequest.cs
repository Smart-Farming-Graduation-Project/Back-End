namespace Croppilot.Core.Features.Notification.Models
{
    public class PushbulletRequest : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
