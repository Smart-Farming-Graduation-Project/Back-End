using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;


namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

internal class RefreshTokenCommandHandler(IAuthenticationService service, IUserService userService)
    : ResponseHandler, IRequestHandler<RefreshTokenCommand, Response<SignInResponse>>
{
    public async Task<Response<SignInResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByUserName(request.UserName);
        if (user is null)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidUser",
                    Message = "Invalid User",
                    Field = "UserName"
                }
            };
            return BadRequest<SignInResponse>(errors, "Authentication error");
        }

        var tokenResponse = await service.RefreshTokenAsync(user, request.RefreshToken);
        if (tokenResponse.RefreshToken == request.RefreshToken)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidToken",
                    Message = "Invalid Token",
                    Field = "RefreshToken"
                }
            };
            return BadRequest<SignInResponse>(errors, "Token error");
        }

        var response = new SignInResponse
        {
            UserName = request.UserName,
            IsAuthenticated = true,
            Tokens = tokenResponse
        };

        return Success(response);
    }
}