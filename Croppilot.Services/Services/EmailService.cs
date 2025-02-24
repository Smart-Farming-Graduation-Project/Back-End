using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Croppilot.Services.Services
{
    public class EmailService(IConfiguration configuration, UserManager<ApplicationUser> userManager) : IEmailService
    {
        public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        {
            MailjetClient client = new MailjetClient(configuration["MailJet:ApiKey"], configuration["MailJet:SecretKey"]);

            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(configuration["Email:From"], configuration["Email:ApplicationName"]))
                .WithSubject(emailSend.Subject)
                .WithTo(new SendContact(emailSend.To))
                .WithVariables(new Dictionary<string, object>
                {
                    { "username", emailSend.UserName },
                    { "confirmation_link", emailSend.Url }

                })
                .WithTemplateId(emailSend.TemplateId)
                .Build();
            var response = await client.SendTransactionalEmailAsync(email);
            return response.Messages != null && response.Messages[0].Status == "success";
        }


        public async Task<bool> SendConfirmEMailAsync(ApplicationUser user)
        {

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{configuration["JwtSettings:Audience"]}/{configuration["Email:ConfirmEmailPath"]}?token={token}&email={user.Email}";
            //var testUrl = $"http://localhost:3000/confirm-email?token={token}&email={user.Email}";
            var emailSend = new EmailSendDto(user.Email, "Confirm your email", url, user.UserName, SD.ConfirmEmailTemplateId);

            return await SendEmailAsync(emailSend);
        }

        public async Task<bool> SendForgotUsernameOrPasswordEmail(ApplicationUser user)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{configuration["JwtSettings:Audience"]}/{configuration["Email:ResetPasswordPath"]}?token={token}&email={user.Email}";

            //var testUrl = $"http://localhost:3000/reset-password?token={token}&email={user.Email}";
            var emailSend = new EmailSendDto(user.Email, "Forgot username or password", url, user.UserName, SD.ResetPasswordTemplateId);

            return await SendEmailAsync(emailSend);
        }

        public async Task<string> SendCodeResetPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user is null) return "UserNotFound";

            // Generate a  OTP
            string otpCode = new Random().Next(100000, 999999).ToString();
            user.OTPCode = otpCode;

            var updateResult = await userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!updateResult.Succeeded) return "FailedToUpdateUser";

            string subject = "Reset Your Password";
            string body = $"<p>Hello {user.FirstName} {user.LastName},</p>" +
                          $"<p>Your OTP for password reset is: <strong>{otpCode}</strong></p>" +
                          "<p>Please use this code to reset your password.</p>" +
                          "<p>If you did not request this, please ignore this email.</p>" +
                          $"<br><p>Best regards,<br>{configuration["Email:ApplicationName"]}</p>";


            var emailSend = new EmailSendDto(email, subject, body);

            bool emailSent = await SendEmailAsync(emailSend);
            return emailSent ? "Success" : "FailedToSendEmail";
        }

        public async Task<string> ResetPasswordUsingOTP(string code, string email)
        {
            var user = await userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user is null) return "NotFound";

            if (user.OTPCode == code)
            {
                // Clear OTP after successful validation
                user.OTPCode = null;
                var updateResult = await userManager.UpdateAsync(user).ConfigureAwait(false);

                return updateResult.Succeeded ? "Success" : "FailedToUpdate";
            }

            return "Failed";
        }
        public async Task<bool> SendEmailForTEst(EmailSendDto emailSend)
        {

            MailjetClient client = new MailjetClient(configuration["MailJet:ApiKey"], configuration["MailJet:SecretKey"]);
            ApplicationUser? user = await userManager.FindByEmailAsync(emailSend.To).ConfigureAwait(false);
            var testUrl = $"http://localhost:3000/confirm-email?token={user.Address}&email={user.Email}";

            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(configuration["Email:From"], configuration["Email:ApplicationName"]))
                .WithSubject(emailSend.Subject)
                .WithTo(new SendContact(emailSend.To))
                .WithVariables(new Dictionary<string, object>
                {
                    { "username", user.UserName },
                    { "confirmation_link", testUrl }

                })
                .WithTemplateId(6754025)
                .Build();

            var response = await client.SendTransactionalEmailAsync(email);
            return response.Messages != null && response.Messages[0].Status == "success";

        }
    }
}
