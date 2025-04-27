using Croppilot.Core.Features.Category.Command.Models;

namespace Croppilot.Core.Features.Category.Command.Validtators
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        public AddCategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            ApplyValidationRules();
            AppluCustomValidationRules();
        }
        private void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(50).WithMessage("Category name cannot exceed 50 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
            RuleFor(x => x.Image)
                .Must(x => x?.Length > 0).WithMessage("Uploaded image cannot be empty.")
                .Must(x => x?.ContentType == "image/jpeg" || x?.ContentType == "image/png")
                .WithMessage("Only JPEG and PNG formats are allowed.")
                .When(x => x.Image != null);
        }

        private void AppluCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    var category = await _categoryService.GetByNameAsync(name, cancellation);
                    return category == null;
                }).WithMessage("This Category Name Is Already Exist");
        }

    }
}