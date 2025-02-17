using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

internal class RevokeRefreshTokenCommandHandler(IAuthenticationService service)
    : ResponseHandler, IRequestHandler<RevokeRefreshTokenCommand, Response<string>>
{
    public async Task<Response<string>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var response = await service.RevokeRefreshTokenAsync(request.RefreshToken);
        if (!response) return BadRequest<string>("Invalid Token");
        return Success("Token Revoked Successfully");
    }
}