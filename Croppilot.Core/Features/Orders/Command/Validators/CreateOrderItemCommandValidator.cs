using Croppilot.Core.Features.Orders.Command.Models;

namespace Croppilot.Core.Features.Orders.Command.Validators;

public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
	public CreateOrderItemCommandValidator()
	{
		RuleFor(x => x.ProductId)
			.GreaterThan(0).WithMessage("ProductId must be greater than 0.");

		RuleFor(x => x.Quantity)
			.GreaterThan(0).WithMessage("Quantity must be greater than 0.");
		RuleFor(x => x.Cupon)
				.MaximumLength(50).WithMessage("Cupon code cannot exceed 50 characters.")
				.MinimumLength(4).WithMessage("Cupon code must be at least 4 characters long.")
				.When(x => !string.IsNullOrEmpty(x.Cupon));

	}
}