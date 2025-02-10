namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class ResendConfirmEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
