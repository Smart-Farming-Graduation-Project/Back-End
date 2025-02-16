using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

internal class RevokeRefreshTokenCommandHandler(IAuthenticationService service)
    : ResponseHandler, IRequestHandler<RevokeRefreshTokenCommand, Response<string>>
{
    public async Task<Response<string>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var revoked = await service.RevokeRefreshTokenAsync(request.RefreshToken);
        if (revoked)
            return Success("Token Revoked Successfully");


        var errors = new List<Error>
        {
            new()
            {
                Code = "InvalidRefreshToken",
                Message = "Invalid Token",
                Field = "RefreshToken"
            }
        };
        return BadRequest<string>(errors, "Invalid Token");
    }
}