using Croppilot.Core.Features.Authorization.Queries.Result;
using Croppilot.Date.Identity;

namespace Croppilot.Core.Mapping.Authorization
{
    internal partial class AuthorizationMapping
	{
		public void GetRoleMapping(TypeAdapterConfig config)
		{
			config.NewConfig<ApplicationRole, GetRole>()
				.Map(dest => dest.RoleName, src => src.Name);
		}
	}
}
