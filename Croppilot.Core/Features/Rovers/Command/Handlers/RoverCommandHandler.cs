using Croppilot.Core.Features.Rovers.Command.Models;

namespace Croppilot.Core.Features.Rovers.Command.Handlers;

public class RoverCommandHandler(IRoverService roverService, IUserService userService) : ResponseHandler,
    IRequestHandler<AddRoverCommand, Response<string>>,
    IRequestHandler<DeleteRoverCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddRoverCommand command, CancellationToken cancellationToken)
    {
        //Check if user exists
        var user = await userService.GetUserByUserName(command.UserName);
        if (user == null)
            return NotFound<string>("User not found.");

        // Check if rover ID already exists
        var roverExists = await roverService.RoverIdExistsAsync(command.RoverId, cancellationToken);
        if (roverExists)
            return BadRequest<string>($"Rover with ID '{command.RoverId}' already exists.");

        var rover = new Date.Models.Rover
        {
            Id = command.RoverId,
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow
        };

        var result = await roverService.CreateRoverAsync(rover, cancellationToken);

        return result == OperationResult.Success
            ? Success<string>($"Rover created successfully with ID: {rover.Id}")
            : BadRequest<string>("Failed to create rover.");
    }

    public async Task<Response<string>> Handle(DeleteRoverCommand command, CancellationToken cancellationToken)
    {
        // Check if user exists
        var user = await userService.GetUserByUserName(command.UserName);
        if (user == null)
            return NotFound<string>("User not found.");

        // First check if the rover exists and belongs to the user
        var rover = await roverService.GetRoverByIdAsync(command.RoverId, cancellationToken);
        if (rover == null)
            return NotFound<string>("Rover not found.");

        if (rover.UserId != user.Id)
            return NotFound<String>("This rover does not belong to the user.");

        var result = await roverService.DeleteRoverAsync(command.RoverId, cancellationToken);

        return result
            ? Success<string>("Rover deleted successfully.")
            : BadRequest<string>("Failed to delete rover.");
    }
}