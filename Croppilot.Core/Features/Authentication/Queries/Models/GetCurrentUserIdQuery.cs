namespace Croppilot.Core.Features.Authentication.Queries.Models;

public class GetCurrentUserIdQuery : IRequest<Response<string>>
{
    public string UserName { get; set; }
}