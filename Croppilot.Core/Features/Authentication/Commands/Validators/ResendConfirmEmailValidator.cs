using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Validators
{
    class ResendConfirmEmailValidator : AbstractValidator<ResendConfirmEmailCommand>
    {
        public ResendConfirmEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }

    }
}
