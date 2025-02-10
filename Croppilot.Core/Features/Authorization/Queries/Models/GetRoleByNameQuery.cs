using Croppilot.Core.Features.Authorization.Queries.Result;

namespace Croppilot.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByNameQuery : IRequest<Response<GetRole>>
	{
		public string RoleName { get; set; }
		public GetRoleByNameQuery(string roleName)
		{
			RoleName = roleName;
		}
	}
}
