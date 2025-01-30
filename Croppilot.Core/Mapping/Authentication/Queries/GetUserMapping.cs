using Croppilot.Core.Featuers.Authentication.Queries.Result;
using Croppilot.Date.Identity;

namespace Croppilot.Core.Mapping.Authentication
{
	public partial class AuthenticationProfile
	{
		void GetUserMapping()
		{
			CreateMap<ApplicationUser, GetUser>()
				.ForMember(dest => dest.FullName, src => src.MapFrom(s => $"{s.FirstName} {s.LastName}"));
		}
	}
}
