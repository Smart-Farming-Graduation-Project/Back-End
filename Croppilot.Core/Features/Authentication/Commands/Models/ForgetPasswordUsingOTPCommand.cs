namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class ForgetPasswordUsingOTPCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
