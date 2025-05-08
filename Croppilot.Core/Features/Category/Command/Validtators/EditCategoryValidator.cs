using Croppilot.Core.Features.Category.Command.Models;

namespace Croppilot.Core.Features.Category.Command.Validtators
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        public EditCategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        private void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Category ID is required.")
                .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(50).WithMessage("Category name cannot exceed 50 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
            RuleFor(x => x.Image)
                .Must(x => x?.Length > 0).WithMessage("Uploaded image cannot be empty.")
                .Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png" ||
                           x.ContentType == "image/jpg")
                .WithMessage("Only JPEG, JPG, and PNG formats are allowed.")
                .When(x => x.Image != null);
        }
        private void ApplyCustomValidationRules()
        {
            RuleFor(x => x).MustAsync(async (command, cancellation) =>
            {
                var category = await _categoryService.GetByNameAsync(command.Name, cancellation);
                return category == null || category.Id == command.Id;
            }).WithMessage("This Category Name Is Already Exist");
        }
    }
}
