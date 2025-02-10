using Croppilot.Date.DTOS;

namespace Croppilot.Services.Abstract
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailSendDto sendEmail);
    }
}
