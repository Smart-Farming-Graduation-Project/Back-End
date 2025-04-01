using Croppilot.Core.Features.Cupon.Command.Models;

namespace Croppilot.Core.Features.Cupon.Command.Validators
{
	public class CreateCuponCommandValidator : AbstractValidator<CreateCuponCommand>
	{
		private readonly ICuponService _cuponService;
		public CreateCuponCommandValidator(ICuponService cuponService)
		{
			_cuponService = cuponService;
			ApplyValidationRules();
			ApplyCustomValidationRules();
		}
		void ApplyValidationRules()
		{
			RuleFor(x => x.CuponCode)
				.NotEmpty().WithMessage("Cupon code is required.")
				.MaximumLength(50).WithMessage("Cupon code cannot exceed 50 characters.")
				.MinimumLength(4).WithMessage("Cupon code must be at least 4 characters long.");
			RuleFor(x => x.DiscountType)
				.NotEmpty().WithMessage("Discount type is required.")
				.IsInEnum().WithMessage("Invalid discount type.Use 'Percentage' or 'Fixed'");
			RuleFor(x => x.DiscountValue)
				.NotEmpty().WithMessage("Discount value is required.")
				.GreaterThan(0).WithMessage("Discount value must be greater than 0.");
			RuleFor(x => x.ExpirationDate)
				.NotEmpty().WithMessage("Expiration date is required.")
				.GreaterThan(DateTime.UtcNow).WithMessage("Expiration date must be greater than current date.");
			RuleFor(x => x.UsageLimit)
				.NotEmpty().WithMessage("Usage limit is required.")
				.GreaterThan(0).WithMessage("Usage limit must be greater than 0.");
		}
		void ApplyCustomValidationRules()
		{
			RuleFor(x => x.CuponCode)
				.MustAsync(async (p, CancellationToken) =>
				{
					return await _cuponService.IsUniqueCode(p);
				}).WithMessage("This cupon code is already taken.");
		}
	}
}
