namespace Croppilot.Core.Features.Product.Command.Validators;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required.")
            .GreaterThan(0).WithMessage("Invalid product ID.");
    }
}