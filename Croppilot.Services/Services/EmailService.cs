using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace Croppilot.Services.Services
{
    public class EmailService(IConfiguration configuration, ILogger<EmailService> logger, UserManager<ApplicationUser> userManager) : IEmailService
    {
        public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        {
            try
            {
                MailjetClient client =
                    new MailjetClient(configuration["MailJet:ApiKey"], configuration["MailJet:SecretKey"]);

                var email = new TransactionalEmailBuilder()
                    .WithFrom(new SendContact(configuration["Email:From"], configuration["Email:ApplicationName"]))
                    .WithSubject(emailSend.Subject)
                    .WithTo(new SendContact(emailSend.To))
                    .WithVariables(emailSend.Variables)
                    .WithTemplateId(emailSend.TemplateId)
                    .Build();

                var response = await client.SendTransactionalEmailAsync(email);
                return response.Messages != null && response.Messages[0].Status == "success";
            }
            catch (Exception ex)
            {
                logger.LogError($"Error sending email: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> SendConfirmEMailAsync(ApplicationUser user)
        {

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{configuration["JwtSettings:Audience"]}/{configuration["Email:ConfirmEmailPath"]}?token={token}&email={user.Email}";
            //var testUrl = $"http://localhost:3000/confirm-email?token={token}&email={user.Email}";

            var variables = new Dictionary<string, object>
            {
                { "username", user.UserName },
                { "confirmation_link", url }
            };
            var emailSend = new EmailSendDto(user.Email, "Confirm your email", url, user.UserName, SD.ConfirmEmailTemplateId, variables);

            return await SendEmailAsync(emailSend);
        }

        public async Task<bool> SendForgotUsernameOrPasswordEmail(ApplicationUser user)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{configuration["JwtSettings:Audience"]}/{configuration["Email:ResetPasswordPath"]}?token={token}&email={user.Email}";
            var variables = new Dictionary<string, object>
            {
                { "username", user.UserName },
                { "reset_password_link", url }
            };
            //var testUrl = $"http://localhost:3000/reset-password?token={token}&email={user.Email}";
            var emailSend = new EmailSendDto(user.Email, "Forgot username or password", url, user.UserName, SD.ResetPasswordTemplateId, variables);

            return await SendEmailAsync(emailSend);
        }

        public async Task<string> SendCodeResetPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null) return "UserNotFound";

            // Generate a secure OTP
            string otpCode = GenerateSecureOtp();
            user.OTPCode = otpCode;
            user.OTPExpiration = DateTime.UtcNow.AddMinutes(10); // OTP expires in 10 minutes

            var updateResult = await userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!updateResult.Succeeded) return "FailedToUpdateUser";
            var variables = new Dictionary<string, object>
            {
                { "username", user.UserName },
                { "otp_code", otpCode }
            };

            var emailSend = new EmailSendDto(user.Email, "OTP Code", null, user.UserName, SD.SendOtpTemplateId, variables);

            bool emailSent = await SendEmailAsync(emailSend);
            return emailSent ? "Success" : "FailedToSendEmail";
        }

        public async Task<string> ResetPasswordUsingOTP(string code, string email)
        {
            var user = await userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null) return "UserNotFound";

            if (user.OTPCode != code)
                return "InvalidOTP";

            if (user.OTPExpiration < DateTime.UtcNow)
                return "OTPExpired";

            // Clear OTP after successful validation
            user.OTPCode = null;
            user.OTPExpiration = null;

            var updateResult = await userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!updateResult.Succeeded) return "FailedToUpdate";

            //  Generate a password reset token
            string resetToken = await userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);

            return resetToken;
        }


        private string GenerateSecureOtp()
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] randomNumber = new byte[4];
            rng.GetBytes(randomNumber);
            int otp = BitConverter.ToUInt16(randomNumber, 0) % 900000 + 100000;
            return otp.ToString();
        }
    }
}
