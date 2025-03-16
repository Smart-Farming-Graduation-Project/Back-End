using Croppilot.Core.Features.Notification.Models;

namespace Croppilot.Core.Features.Notification.Handlers
{
    public class NotificationHandlers(INotificationServices notificationServices) : ResponseHandler,
        IRequestHandler<SmsRequest, Response<string>>,
        IRequestHandler<PushbulletRequest, Response<string>>
    {
        public async Task<Response<string>> Handle(SmsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var messageSid = await notificationServices.SendSmsUsingTwilio(request.To, request.Message);

                return Success(messageSid, "SMS sent successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(PushbulletRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var isSuccess = await notificationServices.SendNotification(request.Title, request.Body);

                if (isSuccess)
                {
                    return Success<string>("Notification sent successfully!");
                }
                else
                {
                    return BadRequest<string>("Failed to send notification.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }
    }
}
