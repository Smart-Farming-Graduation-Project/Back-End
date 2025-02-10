using Croppilot.Core.Features.Orders.Command.Models;

namespace Croppilot.Core.Features.Orders.Command.Validators;

public class EditOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public EditOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Order Id must be greater than 0.");

        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("Shipping Address is required.")
            .MaximumLength(250).WithMessage("Shipping Address cannot exceed 250 characters.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid order status value.");
    }
}