using Croppilot.Core.Features.Orders.Command.Models;

namespace Croppilot.Core.Features.Orders.Command.Validators;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Order Id must be greater than 0.");
    }
}