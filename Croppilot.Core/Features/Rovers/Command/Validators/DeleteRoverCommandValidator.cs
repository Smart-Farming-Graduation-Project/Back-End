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

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("UserName is required.")
            .NotNull()
            .WithMessage("UserName cannot be null.");
    }
} 