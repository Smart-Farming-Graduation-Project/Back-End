namespace Croppilot.Core.Features.Authentication.Queries.Models
{
    public class ResetPasswordUsingOTPQuery : IRequest<Response<string>>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
