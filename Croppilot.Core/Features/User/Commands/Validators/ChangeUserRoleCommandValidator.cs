using Croppilot.Core.Features.User.Commands.Models;

namespace Croppilot.Core.Features.User.Commands.Validators
{
	public class ChangeUserRoleCommandValidator : AbstractValidator<ChangeUserRoleCommand>
	{
		public ChangeUserRoleCommandValidator()
		{
			RuleFor(x => x.UserName).NotNull().NotEmpty().WithName("User Name").WithMessage("{PropertyName} is required");
			RuleFor(x => x.RoleName).NotNull().NotEmpty().WithName("Role Name").WithMessage("{PropertyName} is required");
			RuleFor(x => x.NewRoleName).NotNull().NotEmpty().WithName("New Role Name").WithMessage("{PropertyName} is required");
		}
	}
}
