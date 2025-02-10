using Croppilot.Core.Features.Authentication.Queries.Models;

namespace Croppilot.Core.Features.Authentication.Queries.Handlers
{
    public class ResetPasswordQueryHandlers(IEmailService emailService) : ResponseHandler,
        IRequestHandler<ResetPasswordUsingOTPQuery, Response<string>>
    {
        public async Task<Response<string>> Handle(ResetPasswordUsingOTPQuery request, CancellationToken cancellationToken)
        {
            var result = await emailService.ResetPasswordUsingOTP(request.Code, request.Email);

            switch (result)
            {
                case "NotFound":
                    return NotFound<string>("User not found or email is incorrect.");

                case "Failed":
                    return BadRequest<string>("Invalid OTP,The OTP Code Is Not Correctly. Please try again.");

                case "Success":
                    return Success<string>("The OTP Code Is Correctly.");

                default:
                    return BadRequest<string>(result);
            }
        }

    }
}
