namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class ForgetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
