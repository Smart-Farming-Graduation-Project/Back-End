using Croppilot.Core.Features.Cupon.Command.Models;
using System.Security.Claims;

namespace Croppilot.Core.Features.Cupon.Command.Handlers
{
	class CreateCuponCommandHandler(ICuponService cuponService,
		IHttpContextAccessor httpContextAccessor)
		: ResponseHandler, IRequestHandler<CreateCuponCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(CreateCuponCommand request, CancellationToken cancellationToken)
		{
			var userId = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (string.IsNullOrEmpty(userId))
				return NotFound<string>("User not found.");
			var cupon = request.Adapt<Date.Models.Cupon>();
			cupon.UserId = userId;

			var response = await cuponService.CreateCuponAsync(cupon) == OperationResult.Success
				? Success<string>("Cupon created successfully.")
				: BadRequest<string>("An error occurred while creating the cupon.");
			return response;
		}
	}
}
