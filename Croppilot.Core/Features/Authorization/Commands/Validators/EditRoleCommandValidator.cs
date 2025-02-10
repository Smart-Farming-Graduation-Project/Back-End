using Croppilot.Core.Features.Authorization.Commands.Models;

namespace Croppilot.Core.Features.Authorization.Commands.Validators
{
	public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
	{
		public EditRoleCommandValidator()
		{
			RuleFor(x => x.CurrentName).NotNull().NotEmpty().WithName("Current Role Name").WithMessage("{PropertyName} is required");
			RuleFor(x => x.NewName).NotNull().NotEmpty().WithName("New Role Name").WithMessage("{PropertyName} is required");
		}
	}
}
