namespace Croppilot.Core.Features.Carts.Query.Models;

public class GetCartQuery : IRequest<Response<GetCartResponse>>
{
    public string UserId { get; set; }
}