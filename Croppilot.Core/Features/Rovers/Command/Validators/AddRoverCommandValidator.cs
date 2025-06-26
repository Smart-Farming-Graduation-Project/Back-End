using Croppilot.Core.Features.Rovers.Command.Models;
using FluentValidation;

namespace Croppilot.Core.Features.Rovers.Command.Validators;

public class AddRoverCommandValidator : AbstractValidator<AddRoverCommand>
{
    public AddRoverCommandValidator()
    {
        RuleFor(x => x.RoverId)
            .NotEmpty()
            .WithMessage("Rover ID is required.")
            .NotNull()
            .WithMessage("Rover ID cannot be null.")
            .MaximumLength(50)
            .WithMessage("Rover ID cannot exceed 50 characters.")
            .Matches("^[a-zA-Z0-9_-]+$")
            .WithMessage("Rover ID can only contain letters, numbers, underscores, and hyphens.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.")
            .NotNull()
            .WithMessage("User ID cannot be null.");
    }
} 