using Croppilot.Core.Features.Rovers.Query.Models;
using FluentValidation;

namespace Croppilot.Core.Features.Rovers.Query.Validators;

public class GetUserRoversQueryValidator : AbstractValidator<GetUserRoversQuery>
{
    public GetUserRoversQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.UserName) || !string.IsNullOrEmpty(x.UserId))
            .WithMessage("Either UserName or UserId must be provided.");

        When(x => !string.IsNullOrEmpty(x.UserName), () =>
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty when provided.")
                .MaximumLength(50)
                .WithMessage("UserName cannot exceed 50 characters.");
        });

        When(x => !string.IsNullOrEmpty(x.UserId), () =>
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId cannot be empty when provided.");
        });
    }
} 