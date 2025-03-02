using Croppilot.Core.Features.User.Commands.Models;
using Croppilot.Core.Features.User.Queries.Models;


namespace Croppilot.API.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = nameof(UserRoleEnum.Admin))]
public class UserController(IMediator mediator) : AppControllerBase
{
	[HttpGet("GetUsers")]
	public async Task<IActionResult> GetPaginatedUsers([FromQuery] int pageNumber, int pageSize)
	{
		return Ok(await mediator.Send(new GetUserPaginatedQuery(pageNumber, pageSize)));
	}

	[HttpGet("GetById/{id:guid}")]
	public async Task<IActionResult> GetById(string id)
	{
		var response = await mediator.Send(new GetUserByIdQuery(id));
		return NewResult(response);
	}

	[HttpGet("GetByName/{userName:alpha}")]
	public async Task<IActionResult> GetByName(string userName)
	{
		var response = await mediator.Send(new GetUserByUserNameQuery(userName));
		return NewResult(response);
	}

	[HttpGet("user-roles/Get/{userName:alpha}")]
	public async Task<IActionResult> GetUserRoles(string userName)
	{
		return NewResult(await mediator.Send(new GetUserRolesQuery() { UserName = userName }));
	}

	[HttpPut("user-role/change")]
	[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
	public async Task<IActionResult> ChangeUserRole(ChangeUserRoleCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	[HttpGet("user-role/Get/{roleName:alpha}")]
	public async Task<IActionResult> GetUsersAssignedToRole(string roleName)
	{
		return NewResult(await mediator.Send(new GetUsersAssignedToRoleQuery() { RoleName = roleName }));
	}

	[HttpPut("Edit")]
	public async Task<IActionResult> EditUser(EditUserCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	[HttpDelete("Delete/{id:guid}")]
	public async Task<IActionResult> Delete(string id)
	{
		return NewResult(await mediator.Send(new DeleteUserCommand(id)));
	}

	[HttpDelete("user-role/remove")]
	[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
	public async Task<IActionResult> RemoveUserRole(RemoveUserFromRoleCommand command)
	{
		return NewResult(await mediator.Send(command));
	}
	[AllowAnonymous]
	[HttpPost("IsValidUserNameAndEmail")]
	public async Task<IActionResult> IsValidUserNameAndEmail(CheckUserValidCommand command)
	{
		return NewResult(await mediator.Send(command));
	}
}