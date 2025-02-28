using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;

namespace Croppilot.Services.Abstract
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailSendDto sendEmail);
        Task<bool> SendConfirmEMailAsync(ApplicationUser user);
        Task<bool> SendForgotUsernameOrPasswordEmail(ApplicationUser user);
        Task<string> SendCodeResetPassword(string Email);
        Task<string> ResetPasswordUsingOTP(string code, string email);

        //Task<bool> SendEmailForTEst(EmailSendDto emailSend);
    }
}
