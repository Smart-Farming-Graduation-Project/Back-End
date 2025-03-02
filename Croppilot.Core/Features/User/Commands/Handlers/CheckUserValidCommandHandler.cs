using Croppilot.Core.Features.User.Commands.Models;

namespace Croppilot.Core.Features.User.Commands.Handlers
{
	class CheckUserValidCommandHandler(IUserService service) : ResponseHandler, IRequestHandler<CheckUserValidCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(CheckUserValidCommand request, CancellationToken cancellationToken)
		{
			if (await service.IsUniqueUserName(request.UserName))
			{
				if (await service.IsUniqueEmail(request.Email))
				{
					return Success("Username and email are valid.");
				}
				return BadRequest<string>("This email is already registered.");
			}
			return BadRequest<string>("This username is already taken.");
		}
	}
}
