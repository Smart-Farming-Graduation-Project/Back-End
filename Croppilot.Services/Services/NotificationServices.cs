using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Croppilot.Services.Services
{
    public class NotificationServices(IConfiguration configuration) : INotificationServices
    {
        public async Task<string> SendSmsUsingTwilio(string to, string message)
        {
            TwilioClient.Init(
                configuration["Notification:Twilio:AccountSid"],
                configuration["Notification:Twilio:AuthToken"]
            );

            var messageOptions = new CreateMessageOptions(new PhoneNumber(to))
            {
                From = new PhoneNumber(configuration["Notification:Twilio:PhoneNumber"]),
                MessagingServiceSid = configuration["Notification:Twilio:MessagingServiceSid"],
                Body = message
            };

            // Send the SMS
            var messageResource = await MessageResource.CreateAsync(messageOptions);

            return messageResource.Sid;
        }
    }
}

