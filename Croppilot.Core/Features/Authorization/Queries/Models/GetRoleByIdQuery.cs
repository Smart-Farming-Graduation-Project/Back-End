using Croppilot.Core.Features.Authorization.Queries.Result;

namespace Croppilot.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRole>>
	{
		public string Id { get; set; }
		public GetRoleByIdQuery(string id)
		{
			Id = id;
		}
	}
}
