using Croppilot.Core.Features.Rovers.Command.Models;
using Croppilot.Core.Features.Rovers.Query.Models;
using Croppilot.Date.Enum;

namespace Croppilot.API.Controller;

/// <summary>
/// Controller responsible for managing rover operations including creation, retrieval, and deletion.
/// Provides endpoints for rover management with administrative access control.
/// All operations require Admin role authorization for security and system integrity.
/// </summary>
/// <remarks>
/// This controller handles all rover-related operations including:
/// - Retrieving rovers by user
/// - Getting specific rover details
/// - Adding new rovers to the system
/// - Deleting existing rovers
/// 
/// Access is restricted to users with Admin role only.
/// </remarks>
[SwaggerResponse(200, "Operation completed successfully", typeof(object)),
 SwaggerResponse(400, "Bad request - Invalid operation parameters or validation failure"),
 SwaggerResponse(401, "Unauthorized - User lacks required Admin permissions"),
 SwaggerResponse(404, "Not found - Requested rover or user does not exist"),
 SwaggerResponse(500, "Internal server error - Unexpected system error occurred"),
 Authorize(Policy = nameof(UserRoleEnum.Admin))]
public class RoverController : AppControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoverController"/> class.
    /// </summary>
    /// <param name="mediator">The MediatR mediator instance for handling commands and queries through the CQRS pattern.</param>
    /// <exception cref="ArgumentNullException">Thrown when mediator is null.</exception>
    public RoverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all rovers associated with a specific user account.
    /// </summary>
    /// <param name="userName">The unique username identifying the user whose rovers should be retrieved. Must be a valid, non-empty string.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing:
    /// - 200 OK: List of rovers belonging to the specified user
    /// - 400 Bad Request: Invalid username format or validation failure
    /// - 404 Not Found: User not found in the system
    /// - 401 Unauthorized: Insufficient permissions
    /// </returns>
    /// <remarks>
    /// This endpoint allows administrators to view all rovers owned by a specific user.
    /// Useful for user account management and system oversight.
    /// </remarks>
    [ResponseCache(CacheProfileName = "Default"), 
     HttpGet("GetUserRovers/{userName}"), 
     SwaggerOperation(
         Summary = "Retrieve all rovers for a specific user",
         Description = "**Fetches a comprehensive list of all rovers associated with the specified username. " +
                      "Requires Admin role for security compliance. Returns detailed rover information including " +
                      "rover ID, status, and associated metadata.**")]
    public async Task<IActionResult> GetUserRovers([FromRoute] string userName)
    {
        var response = await _mediator.Send(new GetUserRoversQuery { UserName = userName });
        return NewResult(response);
    }

    /// <summary>
    /// Retrieves detailed information for a specific rover by its unique identifier.
    /// </summary>
    /// <param name="roverId">The unique identifier of the rover to retrieve. Must be a valid, non-empty string.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing:
    /// - 200 OK: Detailed rover information including configuration and status
    /// - 400 Bad Request: Invalid rover ID format
    /// - 404 Not Found: Rover with specified ID does not exist
    /// - 401 Unauthorized: Insufficient permissions
    /// </returns>
    /// <remarks>
    /// This endpoint provides comprehensive details about a specific rover.
    /// Includes rover configuration, current status, and operational metadata.
    /// Access is restricted to ensure only authorized personnel can view rover details.
    /// </remarks>
    [ResponseCache(CacheProfileName = "Default"), 
     HttpGet("GetRover/{roverId}"), 
     SwaggerOperation(
         Summary = "Retrieve specific rover details by ID",
         Description = "**Fetches comprehensive information about a specific rover using its unique identifier. " +
                      "Returns detailed rover data including operational status, configuration parameters, " +
                      "and associated user information. Admin access required for security.**")]
    public async Task<IActionResult> GetRoverById([FromRoute] string roverId)
    {
        var response = await _mediator.Send(new GetRoverByIdQuery { RoverId = roverId });
        return NewResult(response);
    }

    /// <summary>
    /// Creates and registers a new rover in the system for a specific user.
    /// </summary>
    /// <param name="roverId">The unique identifier for the new rover. Must be unique across the entire system and follow naming conventions.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing:
    /// - 200 OK: Rover successfully created and registered
    /// - 400 Bad Request: Invalid rover ID format or ID already exists
    /// - 401 Unauthorized: Insufficient permissions
    /// - 500 Internal Server Error: Database or system error during creation
    /// </returns>
    /// <remarks>
    /// This endpoint allows administrators to register new rovers in the system.
    /// The rover ID must be globally unique and will be associated with the current user.
    /// Once created, the rover can be used for various agricultural monitoring operations.
    /// </remarks>
    [HttpPost("AddRover/{roverId}"), 
     SwaggerOperation(
         Summary = "Register a new rover in the system",
         Description = "**Creates and registers a new rover with the specified unique identifier. " +
                      "The rover will be associated with the current user account. " +
                      "Rover ID must be unique system-wide and follow established naming conventions. " +
                      "Admin privileges required for rover registration.**")]
    public async Task<IActionResult> AddRover([FromRoute] string roverId)
    {
        var command = new AddRoverCommand
        {
            RoverId = roverId,
            UserId = User.GetUserId()!
        };

        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Permanently removes a rover from the system.
    /// </summary>
    /// <param name="roverId">The unique identifier of the rover to be deleted. Must correspond to an existing rover.</param>
    /// <param name="roverUserId">The unique identifier of the user who owns the rover. Used for ownership verification and security.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing:
    /// - 200 OK: Rover successfully deleted from the system
    /// - 400 Bad Request: Invalid rover ID or user ID format
    /// - 404 Not Found: Rover not found or user mismatch
    /// - 401 Unauthorized: Insufficient permissions
    /// - 500 Internal Server Error: Database or system error during deletion
    /// </returns>
    /// <remarks>
    /// This endpoint permanently removes a rover from the system.
    /// Requires both rover ID and owner user ID for security verification.
    /// Once deleted, all rover data and associated records will be permanently removed.
    /// This action cannot be undone, so use with caution.
    /// </remarks>
    [HttpDelete("DeleteRover/{roverId}"), 
     SwaggerOperation(
         Summary = "Permanently delete a rover from the system",
         Description = "**Permanently removes the specified rover from the system after verifying ownership. " +
                      "Requires both rover ID and owner user ID for security verification. " +
                      "This operation is irreversible and will remove all associated rover data. " +
                      "Admin access required for rover deletion operations.**")]
    public async Task<IActionResult> DeleteRover([FromRoute] string roverId, [FromRoute] string roverUserId)
    {
        var command = new DeleteRoverCommand
        {
            RoverId = roverId,
            UserId = roverUserId
        };

        var response = await _mediator.Send(command);
        return NewResult(response);
    }
} 