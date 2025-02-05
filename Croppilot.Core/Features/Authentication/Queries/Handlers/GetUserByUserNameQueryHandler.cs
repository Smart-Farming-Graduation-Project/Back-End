using Croppilot.Core.Features.Authentication.Queries.Models;
using Croppilot.Core.Features.Authentication.Queries.Result;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Features.Authentication.Queries.Handlers
{
    internal class GetUserByUserNameQueryHandler : ResponseHandler,
        IRequestHandler<GetUserByUserNameQuery, Response<GetUser>>
    {
        private readonly IAuthenticationService _service;

        public GetUserByUserNameQueryHandler(UserManager<ApplicationUser> userManager, IAuthenticationService service)
        {
            _service = service;
        }

        public async Task<Response<GetUser>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var userQuery = await _service.GetUserByUserName(request.UserName);
            if (userQuery is null)
                return NotFound<GetUser>("User do not exist");

            var user = userQuery.Adapt<GetUser>();
            return Success(user);
        }
    }
}