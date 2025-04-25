using Croppilot.Core.Features.Notification.Models;

namespace Croppilot.API.Controller
{



    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
    public class NotificationController(IMediator mediator) : AppControllerBase
    {
        [HttpPost("Send-Sms"), SwaggerOperation(
             Summary = "Send an SMS Using Twilio  **donot use before tell me Mohamed Zonkol**",
             Description = "**Sends an SMS message to the specified recipient using Twilio.**\n\n" +
                           "**Parameters:**\n" +
                           "- **To**: The recipient's phone number in E.164 format (e.g., +1234567890).\n" +
                           "- **Message**: The content of the SMS message.\n\n" +
                           "**Returns:**\n" +
                           "- A response indicating whether the SMS was sent successfully, along with the Twilio message SID."
         )]
        public async Task<IActionResult> SendSms([FromBody] SmsRequest command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }


        [HttpPost("Send-Notification"), SwaggerOperation(
             Summary = "Send a Notification Using Pushbullet   **donot use before tell me Mohamed Zonkol**",
             Description = "**Sends a notification to the specified device using Pushbullet.**\n\n" +
                           "**Parameters:**\n" +
                           "- **Title**: The title of the notification.\n" +
                           "- **Body**: The content of the notification.\n\n" +
                           "**Returns:**\n" +
                           "- A response indicating whether the notification was sent successfully."
         )]
        public async Task<IActionResult> SendNotification([FromBody] PushbulletRequest command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }

    }
}
