namespace Croppilot.Core.Features.Authentication.Queries.Models;

public class GetCurrentUserIdQuery : IRequest<Response<Guid>>
{
    public string UserName { get; set; }
}