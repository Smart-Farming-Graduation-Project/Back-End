using Microsoft.AspNetCore.Identity;

namespace Croppilot.Date.Identity
{
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole() { }
		public ApplicationRole(string roleName) : base(roleName) { }
	}
}
