using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Croppilot.Services.Services
{
    public class NotificationServices(IConfiguration configuration, HttpClient httpClient) : INotificationServices
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
                Body = message
            };

            // Send the SMS
            var messageResource = await MessageResource.CreateAsync(messageOptions);

            return messageResource.Sid;
        }

        public async Task<bool> SendNotification(string title, string body)
        {
            try
            {

                var payload = new
                {
                    type = "note",
                    title = title,
                    body = body
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Access-Token", configuration["Notification:Pushbullet:AccessToken"]);
                //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");


                var response = await httpClient.PostAsync(configuration["Notification:Pushbullet:PushbulletApiUrl"], content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

