using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
	internal class AddUserCommandHandler(IAuthenticationService service, IUserService _userService)
		: ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			if (await _userService.GetUserByEmail(request.Email) is not null)
				return BadRequest<string>("Email must be unique");
			if (await _userService.GetUserByUserName(request.UserName) is not null)
				return BadRequest<string>("UserName must be unique");

			var user = request.Adapt<ApplicationUser>();

			var result = await service.CreateUserAsync(user, request.Password);

			if (result.Succeeded)
				return Created(string.Empty, "User Added successfully");
			return BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}