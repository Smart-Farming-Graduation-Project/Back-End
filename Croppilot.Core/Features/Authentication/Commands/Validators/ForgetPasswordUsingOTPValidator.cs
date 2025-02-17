using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Validators
{
    public class ForgetPasswordUsingOTPValidator : AbstractValidator<ForgetPasswordUsingOTPCommand>
    {
        public ForgetPasswordUsingOTPValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
