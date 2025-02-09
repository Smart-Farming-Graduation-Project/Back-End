using Croppilot.Core.Features.User.Queries.Result;

namespace Croppilot.Core.Features.User.Queries.Models
{
	public class GetUserRolesQuery : IRequest<Response<GetUserRoleResult>>
	{
		public string UserName { get; set; }
	}
}
