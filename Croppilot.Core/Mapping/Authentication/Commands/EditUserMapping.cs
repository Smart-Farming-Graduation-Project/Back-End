using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Date.Identity;

namespace Croppilot.Core.Mapping.Authentication
{
	public partial class AuthenticationProfile
	{
		void EditUserMapping()
		{
			CreateMap<EditUserCommand, ApplicationUser>();
		}
	}
}
