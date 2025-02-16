using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Core.Features.Authorization.Queries.Models;


namespace Croppilot.API.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = nameof(UserRoleEnum.Admin))]
public class AuthorizationController(IMediator mediator) : AppControllerBase
{
    [HttpGet("GetRoles")]
    public async Task<IActionResult> GetRoles()
    {
        return NewResult(await mediator.Send(new GetRolesListQuery()));
    }

    [HttpGet("GetById/{id:guid}")]
    public async Task<IActionResult> GetById(string id)
    {
        return NewResult(await mediator.Send(new GetRoleByIdQuery(id)));
    }

    [HttpGet("GetByName/{roleName:alpha}")]
    public async Task<IActionResult> GetByName(string roleName)
    {
        return NewResult(await mediator.Send(new GetRoleByNameQuery(roleName)));
    }

    [HttpPost("Create")]
    //[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
    public async Task<IActionResult> CreateRole(AddRoleCommand command)
    {
        return NewResult(await mediator.Send(command));
    }

    [HttpPut("Edit")]
    [Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
    public async Task<IActionResult> Edit(EditRoleCommand command)
    {
        return NewResult(await mediator.Send(command));
    }

    [HttpDelete("Delete")]
    [Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
    public async Task<IActionResult> Delete(DeleteRoleCommand command)
    {
        return NewResult(await mediator.Send(command));
    }

    [HttpPost("user-role/assign")]
    //[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
    public async Task<IActionResult> AssignRole(AssignRolesToUserCommand command)
    {
        return NewResult(await mediator.Send(command));
    }
}