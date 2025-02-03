using Croppilot.Core.Features.Product.Query.Models;

namespace Croppilot.Core.Features.Product.Query.Validators
{
    public class GetProductPaginatedQueryValidator : AbstractValidator<GetProductPaginatedQuery>
    {
        public GetProductPaginatedQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.");

            RuleFor(x => x.OrderBy)
                .IsInEnum().WithMessage("Invalid ordering value.");

            RuleFor(x => x.Search)
                .MaximumLength(255).WithMessage("Search term cannot exceed 255 characters.")
                .When(x => !string.IsNullOrEmpty(x.Search)); // Apply only if Search is provided
        }
    }
}