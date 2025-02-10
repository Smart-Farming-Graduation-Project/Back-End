using Croppilot.API.Bases;
using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Core.Features.Authorization.Queries.Models;
using Croppilot.Date.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Policy = nameof(UserRoleEnum.Admin))]
	public class AuthorizationController : AppControllerBase
	{
		private readonly IMediator _mediator;
		public AuthorizationController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet("GetRoles")]
		public async Task<IActionResult> GetRoles()
		{
			return NewResult(await _mediator.Send(new GetRolesListQuery()));
		}

		[HttpGet("GetById/{id:guid}")]
		public async Task<IActionResult> GetById(string id)
		{
			return NewResult(await _mediator.Send(new GetRoleByIdQuery(id)));
		}

		[HttpGet("GetByName/{roleName:alpha}")]
		public async Task<IActionResult> GetByName(string roleName)
		{
			return NewResult(await _mediator.Send(new GetRoleByNameQuery(roleName)));
		}

		[HttpPost("Create")]
		//[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
		public async Task<IActionResult> CreateRole(AddRoleCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpPut("Edit")]
		[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
		public async Task<IActionResult> Edit(EditRoleCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpDelete("Delete")]
		[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
		public async Task<IActionResult> Delete(DeleteRoleCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpPost("user-role/assign")]
		//[Authorize(Policy = nameof(UserRoleEnum.SuperAdmin))]
		public async Task<IActionResult> AssignRole(AssignRolesToUserCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}
	}
}
