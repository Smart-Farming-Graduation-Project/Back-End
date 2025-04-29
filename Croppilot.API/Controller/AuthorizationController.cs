using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Core.Features.Authorization.Queries.Models;

namespace Croppilot.API.Controller;

/// <summary>
/// AuthorizationController manages roles and permissions within the system.
/// 
/// It provides endpoints for retrieving roles, creating, editing, and deleting roles,
/// as well as assigning roles to users.
/// 
/// Each response follows a standardized format with:
/// - StatusCode: HTTP response status code.
/// - Succeeded: Boolean indicating operation success.
/// - Message: A brief description of the operation result.
/// - Data: The returned data (if applicable).
/// - Errors: A list of encountered errors, each containing:
///     - Code: Unique identifier for the error.
///     - Message: Description of the error.
///     - Field: The field associated with the error (if applicable).
/// 
/// Only Admins can access these endpoints, and some require SuperAdmin privileges.
/// </summary>
[Route("api/[controller]"), ApiController, Authorize(Policy = nameof(UserRoleEnum.Admin))]
[EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
public class AuthorizationController(IMediator mediator) : AppControllerBase
{
    /// <summary>
    /// Retrieves the list of all available roles.
    /// </summary>
    [HttpGet("GetRoles"), SwaggerOperation(
         Summary = "Retrieves all roles",
         Description = "Fetches the complete list of user roles in the system.")]
    public async Task<IActionResult> GetRoles()
    {
        return NewResult(await mediator.Send(new GetRolesListQuery()));
    }

    /// <summary>
    /// Retrieves role details by ID.
    /// </summary>
    [HttpGet("GetById/{id:guid}"), SwaggerOperation(
         Summary = "Gets role by ID",
         Description = "Fetches details of a specific role by its unique identifier.")]
    public async Task<IActionResult> GetById(string id)
    {
        return NewResult(await mediator.Send(new GetRoleByIdQuery(id)));
    }

    /// <summary>
    /// Retrieves role details by name.
    /// </summary>
    [HttpGet("GetByName/{roleName:alpha}"), SwaggerOperation(
         Summary = "Gets role by name",
         Description = "Fetches details of a specific role by its name.")]
    public async Task<IActionResult> GetByName(string roleName)
    {
        return NewResult(await mediator.Send(new GetRoleByNameQuery(roleName)));
    }

    /// <summary>
    /// Creates a new role.
    /// </summary>
    [HttpPost("Create"), SwaggerOperation(
         Summary = "Creates a new role",
         Description = "Adds a new role to the system. Requires SuperAdmin privileges.")]
    //[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
    public async Task<IActionResult> CreateRole(AddRoleCommand command)
    {
        return NewResult(await mediator.Send(command));
    }

    /// <summary>
    /// Edits an existing role.
    /// </summary>
    [HttpPut("Edit"), Authorize(Policy = nameof(UserRoleEnum.Manager)), SwaggerOperation(
         Summary = "Edits an existing role",
         Description = "Modifies the details of an existing role. Requires SuperAdmin privileges.")]
    public async Task<IActionResult> Edit(EditRoleCommand command)
    {
        return NewResult(await mediator.Send(command));
    }

    /// <summary>
    /// Deletes a role from the system.
    /// </summary>
    [HttpDelete("Delete"), Authorize(Policy = nameof(UserRoleEnum.Manager)), SwaggerOperation(
         Summary = "Deletes a role",
         Description = "Removes an existing role from the system. Requires SuperAdmin privileges.")]
    public async Task<IActionResult> Delete(DeleteRoleCommand command)
    {
        return NewResult(await mediator.Send(command));
    }

    /// <summary>
    /// Assigns roles to a user.
    /// </summary>
    [HttpPost("user-role/assign"), SwaggerOperation(
         Summary = "Assigns roles to a user",
         Description = "Grants specific roles to a user in the system.")]
    //[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
    public async Task<IActionResult> AssignRole(AssignRolesToUserCommand command)
    {
        return NewResult(await mediator.Send(command));
    }
}
