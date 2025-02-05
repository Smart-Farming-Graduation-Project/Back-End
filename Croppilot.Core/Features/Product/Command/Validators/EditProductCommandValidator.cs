namespace Croppilot.Core.Features.Product.Command.Validators;

public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required.")
            .GreaterThan(0).WithMessage("Invalid product ID.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Name field is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The Description field is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("The Category Name field is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Availability)
            .IsInEnum().WithMessage("Invalid Availability value.");

        RuleFor(x => x.Images)
            .NotEmpty().WithMessage("At least one image is required.")
            .Must(images => images.All(img => img.Length > 0))
            .WithMessage("Uploaded images cannot be empty.");
    }
}