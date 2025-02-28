using Croppilot.Core.Features.Authentication.Queries.Models;

namespace Croppilot.Core.Features.Authentication.Queries.Handlers
{
    public class ResetPasswordQueryHandlers(IEmailService emailService) : ResponseHandler,
        IRequestHandler<ResetPasswordUsingOTPQuery, Response<string>>
    {
        public async Task<Response<string>> Handle(ResetPasswordUsingOTPQuery request, CancellationToken cancellationToken)
        {
            var result = await emailService.ResetPasswordUsingOTP(request.Code, request.Email).ConfigureAwait(false);

            return result switch
            {
                "UserNotFound" => NotFound<string>("User not found or email is incorrect."),
                "InvalidOTP" => BadRequest<string>("Invalid OTP. The OTP code is incorrect. Please try again."),
                "OTPExpired" => BadRequest<string>("The OTP code has expired. Please request a new one."),
                "FailedToUpdate" => BadRequest<string>("Failed to update user information. Please try again."),
                _ when !string.IsNullOrEmpty(result) => Success<string>("OTP verified successfully. Use this token to reset your password.", result),
                _ => BadRequest<string>("An unexpected error occurred while processing your request.")
            };
        }

    }
}
