using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
	public interface IAuthorizationService
	{
		Task<IdentityResult> CreteRoleAsync(string roleName);
		Task<bool> IsRoleExistAsync(string roleName);
		Task<IdentityResult> EditRoleAsync(ApplicationRole role, string newName);
		Task<ApplicationRole> GetRoleByNameAsync(string roleName);
		Task<ApplicationRole> GetRoleByIdAsync(string id);
		Task<IdentityResult> DeleteRoleAsync(ApplicationRole role);
		Task<bool> IsRoleFree(string roleName);
		Task<List<ApplicationRole>> GetRolesAsync();
		Task<IdentityResult> AssignRolesToUser(ApplicationUser user, List<string> roles);
	}
}
