using Croppilot.Core.Features.User.Commands.Models;

namespace Croppilot.Core.Features.User.Commands.Validators
{
	public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
	{
		private readonly IUserService _userService;
		public EditUserCommandValidator(IUserService userService)
		{
			_userService = userService;
			ApplyValidationRules();
			ApplyCustomValidationRules();
		}

		private void ApplyValidationRules()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty().WithMessage("First name is required.")
				.MaximumLength(50).WithMessage("First name cannot exceed 50 characters.")
				.Matches(@"^[a-zA-Z]+$").WithMessage("First name must contain only letters.");

			RuleFor(x => x.LastName)
				.NotEmpty().WithMessage("Last name is required.")
				.MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.")
				.Matches(@"^[a-zA-Z]+$").WithMessage("Last name must contain only letters.");

			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username is required.")
				.MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
				.MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");


			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Phone number is required.")
				.Matches(@"^\d{11}$").WithMessage("Phone number must be exactly 11 digits.");

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Address is required.")
				.MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

		}

		private void ApplyCustomValidationRules()
		{
			RuleFor(x => x.UserName)
				.MustAsync(
				async (x, CancellationToken) =>
				await _userService.GetUserByUserName(x) == null)
				.WithMessage("This username is already taken.");
		}

	}
}