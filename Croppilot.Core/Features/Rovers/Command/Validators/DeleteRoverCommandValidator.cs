using Croppilot.Core.Features.Rovers.Command.Models;
using FluentValidation;

namespace Croppilot.Core.Features.Rovers.Command.Validators;

public class DeleteRoverCommandValidator : AbstractValidator<DeleteRoverCommand>
{
    public DeleteRoverCommandValidator()
    {
        RuleFor(x => x.RoverId)
            .NotEmpty()
            .WithMessage("Rover ID is required.")
            .NotNull()
            .WithMessage("Rover ID cannot be null.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.")
            .NotNull()
            .WithMessage("User ID cannot be null.");
    }
} 