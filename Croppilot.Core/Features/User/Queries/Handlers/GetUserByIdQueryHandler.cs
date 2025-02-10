using Croppilot.Core.Features.User.Queries.Models;
using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.User.Queries.Handlers
{
	internal class GetUserByIdQueryHandler(IUserService service)
		: ResponseHandler, IRequestHandler<GetUserByIdQuery, Response<GetUser>>
	{
		public async Task<Response<GetUser>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var userQuery = await service.GetUserById(request.Id);

			if (userQuery is null)
				return NotFound<GetUser>("User does not exist");

			var mappedUser = userQuery.Adapt<GetUser>(); // mapping with mapster

			return Success(mappedUser);
		}
	}
}