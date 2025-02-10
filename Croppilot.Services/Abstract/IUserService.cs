using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
	public interface IUserService
	{
		Task<ApplicationUser> GetUserById(string id);
		Task<ApplicationUser> GetUserByUserName(string userName);
		Task<ApplicationUser> GetUserByEmail(string email);
		Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
		Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
		Task<bool> IsUserAssignedToRole(ApplicationUser user, string role);
		Task<List<string>> GetUserRolesAsync(ApplicationUser user);
		Task<IdentityResult> ChangeUserRole(ApplicationUser user, string roleName, string newRoleName);
		Task<List<ApplicationUser>> GetUsersAssignedToRole(string roleName);
		Task<IdentityResult> RemoveUserRoleAsync(ApplicationUser user, string roleName);
	}
}
