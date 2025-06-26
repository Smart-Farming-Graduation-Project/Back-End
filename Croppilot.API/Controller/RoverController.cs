using System.ComponentModel.DataAnnotations;
using Croppilot.Core.Features.Rovers.Command.Models;
using Croppilot.Core.Features.Rovers.Query.Models;
using Croppilot.Date.Enum;

namespace Croppilot.API.Controller;

/// <summary>
/// Controller for managing rover operations including CRUD operations and user associations.
/// Restricted to Admin role for security and system integrity.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = nameof(UserRoleEnum.Admin))]
[SwaggerResponse(401, "Unauthorized - Admin role required")]
[SwaggerResponse(500, "Internal server error")]
public class RoverController : AppControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the RoverController.
    /// </summary>
    /// <param name="mediator">MediatR instance for CQRS operations</param>
    public RoverController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <summary>
    /// Gets all rovers in the system.
    /// </summary>
    /// <returns>List of all rovers</returns>
    [HttpGet]
    [ResponseCache(CacheProfileName = "Default")]
    [SwaggerOperation(
        Summary = "Get all rovers",
        Description = "Retrieves all rovers in the system for administrative oversight.")]
    [SwaggerResponse(200, "Rovers retrieved successfully")]
    public async Task<IActionResult> GetAllRovers()
    {
        var query = new GetAllRoversQuery();
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Gets all rovers associated with a specific user.
    /// </summary>
    /// <param name="userName">Username to retrieve rovers for</param>
    /// <returns>List of user's rovers</returns>
    [HttpGet("user/{userName}/rovers")]
    [ResponseCache(CacheProfileName = "Default")]
    [SwaggerOperation(
        Summary = "Get all rovers for a user",
        Description = "Retrieves all rovers associated with the specified username.")]
    [SwaggerResponse(200, "Rovers retrieved successfully")]
    [SwaggerResponse(400, "Invalid username")]
    [SwaggerResponse(404, "User not found")]
    public async Task<IActionResult> GetUserRovers(
        [FromRoute, Required, MinLength(1)] string userName)
    {
        var query = new GetUserRoversQuery { UserName = userName };
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Gets detailed information for a specific rover.
    /// </summary>
    /// <param name="roverId">Unique rover identifier</param>
    /// <returns>Rover details</returns>
    [HttpGet("{roverId}")]
    [ResponseCache(CacheProfileName = "Default")]
    [SwaggerOperation(
        Summary = "Get rover by ID",
        Description = "Retrieves detailed information for the specified rover.")]
    [SwaggerResponse(200, "Rover retrieved successfully")]
    [SwaggerResponse(400, "Invalid rover ID")]
    [SwaggerResponse(404, "Rover not found")]
    public async Task<IActionResult> GetRoverById(
        [FromRoute, Required, MinLength(1)] string roverId)
    {
        var query = new GetRoverByIdQuery { RoverId = roverId };
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Creates a new rover and associates it with a user.
    /// </summary>
    /// <param name="roverId">Unique identifier for the new rover</param>
    /// <param name="userName">UserName to associate the rover with</param>
    /// <returns>Result of rover creation</returns>
    [HttpPost("{roverId}/user/{userName}")]
    [SwaggerOperation(
        Summary = "Create a new rover",
        Description = "Creates and registers a new rover with the specified ID and associates it with a user.")]
    [SwaggerResponse(200, "Rover created successfully")]
    [SwaggerResponse(400, "Invalid parameters or rover ID already exists")]
    [SwaggerResponse(409, "Rover with this ID already exists")]
    public async Task<IActionResult> CreateRover(
        [FromRoute, Required, MinLength(1)] string roverId,
        [FromRoute, Required, MinLength(1)] string userName)
    {
        var command = new AddRoverCommand
        {
            RoverId = roverId,
            UserName = userName
        };

        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Permanently deletes a rover from the system.
    /// </summary>
    /// <param name="roverId">Rover ID to delete</param>
    /// <param name="userName">Owner userName for verification</param>
    /// <returns>Result of rover deletion</returns>
    [HttpDelete("{roverId}/user/{userName}")]
    [SwaggerOperation(
        Summary = "Delete a rover",
        Description = "Permanently removes a rover from the system after verifying ownership.")]
    [SwaggerResponse(200, "Rover deleted successfully")]
    [SwaggerResponse(400, "Invalid parameters")]
    [SwaggerResponse(404, "Rover not found or user mismatch")]
    public async Task<IActionResult> DeleteRover(
        [FromRoute, Required, MinLength(1)] string roverId,
        [FromRoute, Required, MinLength(1)] string userName)
    {
        var command = new DeleteRoverCommand
        {
            RoverId = roverId,
            UserName = userName
        };

        var response = await _mediator.Send(command);
        return NewResult(response);
    }
} 