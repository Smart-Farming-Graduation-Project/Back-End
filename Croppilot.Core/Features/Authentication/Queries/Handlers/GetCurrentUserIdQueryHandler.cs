using Croppilot.Core.Features.Authentication.Queries.Models;


namespace Croppilot.Core.Features.Authentication.Queries.Handlers;

public class GetCurrentUserIdQueryHandler(IUserService userService)
    : ResponseHandler, IRequestHandler<GetCurrentUserIdQuery, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(GetCurrentUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByUserName(request.UserName);
        if (user == null)
        {
            return NotFound<Guid>("User not found");
        }

        return Success(new Guid(user.Id));
    }
}