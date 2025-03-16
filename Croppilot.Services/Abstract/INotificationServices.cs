namespace Croppilot.Services.Abstract
{
    public interface INotificationServices
    {
        Task<string> SendSmsUsingTwilio(string to, string message);
    }
}
