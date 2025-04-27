using Croppilot.Core.Features.User.Commands.Models;
using Croppilot.Core.Features.User.Queries.Models;


namespace Croppilot.API.Controller;

[Route("api/[controller]"), ApiController]
public class UserController(IMediator mediator) : AppControllerBase
{
	[ResponseCache(CacheProfileName = "NoCache"), HttpGet("GetUsers"), Authorize(Policy = nameof(UserRoleEnum.Admin))]
	public async Task<IActionResult> GetPaginatedUsers([FromQuery] int pageNumber, int pageSize)
	{
		return NewResult(await mediator.Send(new GetUserPaginatedQuery(pageNumber, pageSize)));
	}

	[ResponseCache(CacheProfileName = "Default"), HttpGet("GetById/{id:guid}"), Authorize(Policy = nameof(UserRoleEnum.Admin))]
	public async Task<IActionResult> GetById(string id)
	{
		var response = await mediator.Send(new GetUserByIdQuery(id));
		return NewResult(response);
	}

	[ResponseCache(CacheProfileName = "Default"), HttpGet("GetByName/{userName:alpha}"), Authorize(Policy = nameof(UserRoleEnum.Admin))]
	public async Task<IActionResult> GetByName(string userName)
	{
		var response = await mediator.Send(new GetUserByUserNameQuery(userName));
		return NewResult(response);
	}

	[ResponseCache(CacheProfileName = "Default"), HttpGet("user-roles/Get/{userName:alpha}"), Authorize(Policy = nameof(UserRoleEnum.Admin))]
	public async Task<IActionResult> GetUserRoles(string userName)
	{
		return NewResult(await mediator.Send(new GetUserRolesQuery() { UserName = userName }));
	}

	[HttpPut("user-role/change"), Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
	public async Task<IActionResult> ChangeUserRole(ChangeUserRoleCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	[HttpGet("user-role/Get/{roleName:alpha}")]
	[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
	public async Task<IActionResult> GetUsersAssignedToRole(string roleName)
	{
		return NewResult(await mediator.Send(new GetUsersAssignedToRoleQuery() { RoleName = roleName }));
	}

	[HttpPut("Edit")]
	[Authorize(Policy = nameof(UserRoleEnum.User))]
	public async Task<IActionResult> EditUser(EditUserCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	[HttpDelete("Delete/{id:guid}"), Authorize(Policy = nameof(UserRoleEnum.Admin))]
	public async Task<IActionResult> Delete(string id)
	{
		return NewResult(await mediator.Send(new DeleteUserCommand(id)));
	}

	[HttpDelete("user-role/remove"), Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
	public async Task<IActionResult> RemoveUserRole(RemoveUserFromRoleCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	[AllowAnonymous, HttpPost("IsValidUserNameAndEmail")]
	public async Task<IActionResult> IsValidUserNameAndEmail(CheckUserValidCommand command)
	{
		return NewResult(await mediator.Send(command));
	}
	[HttpPut("ChangeImage")]
	[Authorize(Policy = nameof(UserRoleEnum.User))]
	[SwaggerOperation(Summary = "Change user image",
		Description = "Change user image. Only JPEG and PNG formats are allowed")]
	public async Task<IActionResult> ChangeImage([FromForm] ChangeUserImageCommand command)
	{
		return NewResult(await mediator.Send(command));
	}
}