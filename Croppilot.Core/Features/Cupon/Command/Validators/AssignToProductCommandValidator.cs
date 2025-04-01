using Croppilot.Core.Features.Cupon.Command.Models;

namespace Croppilot.Core.Features.Cupon.Command.Validators
{
	public class AssignToProductCommandValidator : AbstractValidator<AssignToProductCommand>
	{
		public AssignToProductCommandValidator()
		{
			ApplyValidationRules();
		}
		void ApplyValidationRules()
		{
			RuleFor(x => x.CuponId).NotEmpty().WithMessage("CuponId is required.");
			RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
		}
	}
}
