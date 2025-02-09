using Croppilot.Core.Features.Authorization.Commands.Models;

namespace Croppilot.Core.Features.Authorization.Commands.Validators
{
	public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
	{
		public AddRoleCommandValidator()
		{
			RuleFor(x => x.RoleName).NotNull().NotEmpty().WithName("Role Name").WithMessage("{PropertyName} is required");
		}
	}
}
