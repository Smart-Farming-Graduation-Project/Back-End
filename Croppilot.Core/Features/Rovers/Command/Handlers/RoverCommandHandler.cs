using Croppilot.Core.Features.Rovers.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Rovers.Command.Handlers;

public class RoverCommandHandler(IRoverService roverService,IUserService userService) : ResponseHandler,
    IRequestHandler<AddRoverCommand, Response<string>>,
    IRequestHandler<DeleteRoverCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddRoverCommand command, CancellationToken cancellationToken)
    {
        //Check if user exists
        var user = await userService.GetUserById(command.UserId);
        if (user == null)
            return NotFound<string>("User not found.");
        
        // Check if rover ID already exists
        var roverExists = await roverService.RoverIdExistsAsync(command.RoverId, cancellationToken);
        if (roverExists)
            return BadRequest<string>($"Rover with ID '{command.RoverId}' already exists.");

        var rover = new Rover
        {
            Id = command.RoverId,
            UserId = command.UserId,
            CreatedAt = DateTime.UtcNow
        };

        var result = await roverService.CreateRoverAsync(rover, cancellationToken);
        
        return result == OperationResult.Success
            ? Success<string>($"Rover created successfully with ID: {rover.Id}")
            : BadRequest<string>("Failed to create rover.");
    }

    public async Task<Response<string>> Handle(DeleteRoverCommand command, CancellationToken cancellationToken)
    {
        // First check if the rover exists and belongs to the user
        var rover = await roverService.GetRoverByIdAsync(command.RoverId, cancellationToken);
        if (rover == null)
            return NotFound<string>("Rover not found.");

        if (rover.UserId != command.UserId)
            return NotFound<String>("This rover does not belong to the user.");

        var result = await roverService.DeleteRoverAsync(command.RoverId, cancellationToken);
        
        return result
            ? Success<string>("Rover deleted successfully.")
            : BadRequest<string>("Failed to delete rover.");
    }
} 