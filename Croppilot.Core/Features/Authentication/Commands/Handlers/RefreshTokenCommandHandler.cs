using Croppilot.Core.Bases;
using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    internal class RefreshTokenCommandHandler(IAuthenticationService service)
        : ResponseHandler, IRequestHandler<RefreshTokenCommand, Response<SignInResponse>>
    {
        public async Task<Response<SignInResponse>> Handle(RefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            var user = await service.GetUserByUserName(request.UserName);
            if (user is null) return BadRequest<SignInResponse>("Invalid User");
            var tokenResponse = await service.RefreshTokenAsync(user, request.RefreshToken);
            if (tokenResponse.RefreshToken == request.RefreshToken) return BadRequest<SignInResponse>("Invalid Token");
            var response = new SignInResponse()
            {
                UserName = request.UserName,
                IsAuthenticated = true,
                Tokens = tokenResponse
            };
            return Success(response);
        }
    }
}