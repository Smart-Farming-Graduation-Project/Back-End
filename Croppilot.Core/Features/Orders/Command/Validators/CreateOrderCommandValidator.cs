using Croppilot.Core.Features.Orders.Command.Models;

namespace Croppilot.Core.Features.Orders.Command.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("Shipping Address is required.");

        RuleFor(x => x.OrderItems)
            .NotEmpty().WithMessage("At least one order item is required.");

        RuleForEach(x => x.OrderItems).SetValidator(new CreateOrderItemCommandValidator());
    }
}