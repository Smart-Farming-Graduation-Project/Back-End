namespace Croppilot.Services.Abstract
{
    public interface INotificationServices
    {
        Task<string> SendSmsUsingTwilio(string to, string message);
        Task<bool> SendNotification(string title, string body);
    }
}
