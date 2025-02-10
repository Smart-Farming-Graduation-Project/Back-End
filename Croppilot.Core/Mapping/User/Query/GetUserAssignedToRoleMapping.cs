using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Date.Identity;

namespace Croppilot.Core.Mapping.User
{
	public partial class UserMapping
	{
		public void GetUserAsignedToRoleMapping(TypeAdapterConfig config)
		{
			config.NewConfig<ApplicationUser, GetUserAssignedToRoleResponse>();
		}
	}
}
