using AutoMapper;

namespace Croppilot.Core.Mapping.Authentication
{
	public partial class AuthenticationProfile : Profile
	{
		public AuthenticationProfile()
		{
			AddUserMapping();
			GetUserMapping();
			EditUserMapping();
		}
	}
}
