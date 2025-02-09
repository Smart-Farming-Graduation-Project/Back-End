using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Date.Identity;

namespace Croppilot.Core.Mapping.User
{
	public partial class UserMapping
	{
		public void GetUserMapping(TypeAdapterConfig config)
		{
			config.NewConfig<ApplicationUser, GetUser>()
				.Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
		}
	}
}
