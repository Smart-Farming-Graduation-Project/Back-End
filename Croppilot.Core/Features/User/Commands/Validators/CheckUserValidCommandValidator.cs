using Croppilot.Core.Features.User.Commands.Models;

namespace Croppilot.Core.Features.User.Commands.Validators
{
	class CheckUserValidCommandValidator : AbstractValidator<CheckUserValidCommand>
	{
		public CheckUserValidCommandValidator()
		{
			ApplyValidationRules();
		}
		void ApplyValidationRules()
		{
			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username is required.")
				.MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
				.MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("Invalid email format.");
		}
	}
}
