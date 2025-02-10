using Croppilot.Core.Features.Authorization.Commands.Models;

namespace Croppilot.Core.Features.Authorization.Commands.Validators
{
	public class AssignRolesToUserCommandValidator : AbstractValidator<AssignRolesToUserCommand>
	{
		public AssignRolesToUserCommandValidator()
		{
			RuleFor(x => x.UserName).NotNull().NotEmpty().WithName("User Name").WithMessage("{PropertyName is Required}");
			RuleFor(x => x.Roles).NotNull().NotEmpty().ForEach(role =>
			{
				role.NotNull().NotEmpty().WithMessage("Role {CollectionIndex} is required");
			});
		}
	}
}
