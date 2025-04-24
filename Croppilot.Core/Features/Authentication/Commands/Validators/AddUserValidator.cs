using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Validators
{
	public class AddUserValidator : AbstractValidator<AddUserCommand>
	{
		private readonly IUserService _userService;

		public AddUserValidator(IUserService userService)
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

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("Invalid email format.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required.")
				.MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
				.Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
				.Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
				.Matches(@"\d").WithMessage("Password must contain at least one number.")
				.Matches(@"[!@#$%^&*(),.?""{}|<>]").WithMessage("Password must contain at least one special character.");

			RuleFor(x => x.ConfirmPassword)
				.NotEmpty().WithMessage("Confirm password is required.")
				.Equal(x => x.Password).WithMessage("Passwords do not match.");

			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Phone number is required.")
				.Matches(@"^\d{11}$").WithMessage("Phone number must be exactly 11 digits.")
				.When(x => !string.IsNullOrWhiteSpace(x.Phone));

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Address is required.")
				.MaximumLength(200).WithMessage("Address cannot exceed 200 characters.")
				.When(x => !string.IsNullOrWhiteSpace(x.Address));

			RuleFor(x => x.Image)
				.NotEmpty().WithMessage("Image is required.")
				.Must(x => x.Length > 0).WithMessage("Uploaded image cannot be empty.")
				.Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png")
				.WithMessage("Only JPEG and PNG formats are allowed.");

		}

		private void ApplyCustomValidationRules()
		{
			RuleFor(x => x.UserName)
				.MustAsync(BeUniqueUserName).WithMessage("This username is already taken.");

			RuleFor(x => x.Email)
				.MustAsync(BeUniqueEmail).WithMessage("This email is already registered.");
		}

		private async Task<bool> BeUniqueUserName(string userName, CancellationToken cancellationToken)
		{
			return await _userService.GetUserByUserName(userName) == null;
		}

		private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
		{
			return await _userService.GetUserByEmail(email) == null;
		}
	}
}
