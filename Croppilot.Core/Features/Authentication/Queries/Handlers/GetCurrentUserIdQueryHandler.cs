using Croppilot.Core.Features.Authentication.Queries.Models;


namespace Croppilot.Core.Features.Authentication.Queries.Handlers;

public class GetCurrentUserIdQueryHandler(IUserService userService)
    : ResponseHandler, IRequestHandler<GetCurrentUserIdQuery, Response<string>>
{
    public async Task<Response<string>> Handle(GetCurrentUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByUserName(request.UserName);
        return user == null ? NotFound<string>("User not found") : Success(user.Id);
    }
}