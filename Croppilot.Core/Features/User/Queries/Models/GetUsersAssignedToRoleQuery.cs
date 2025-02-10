using Croppilot.Core.Features.User.Queries.Result;

namespace Croppilot.Core.Features.User.Queries.Models
{
	public class GetUsersAssignedToRoleQuery : IRequest<Response<List<GetUserAssignedToRoleResponse>>>
	{
		public string RoleName { get; set; }
	}
}
