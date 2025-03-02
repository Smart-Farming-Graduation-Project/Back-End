using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Croppilot.Services.Services
{
	internal class UserService(UserManager<ApplicationUser> userManager) : IUserService
	{
		public async Task<ApplicationUser?> GetUserByEmail(string email)
		{
			return await userManager.FindByEmailAsync(email);
		}

		public async Task<ApplicationUser?> GetUserById(string id)
		{
			return await userManager.FindByIdAsync(id);
		}

		public async Task<ApplicationUser?> GetUserByUserName(string userName)
		{
			return await userManager.Users
				.Include(u => u.RefreshTokens)
				.Where(u => u.UserName.Equals(userName))
				.FirstOrDefaultAsync();
			//return await userManager.FindByNameAsync(userName);
		}

		public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
		{
			return await userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
		{
			return await userManager.DeleteAsync(user);
		}

		public async Task<bool> IsUserAssignedToRole(ApplicationUser user, string role)
		{
			return await userManager.IsInRoleAsync(user, role);
		}

		public async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
		{
			return (await userManager.GetRolesAsync(user)).ToList();
		}

		public async Task<IdentityResult> ChangeUserRole(ApplicationUser user, string roleName, string newRoleName)
		{
			var result = await userManager.RemoveFromRoleAsync(user, roleName);
			if (!result.Succeeded) return result;
			return await userManager.AddToRoleAsync(user, newRoleName);
		}

		public async Task<List<ApplicationUser>> GetUsersAssignedToRole(string roleName)
		{
			return (await userManager.GetUsersInRoleAsync(roleName)).ToList();
		}

		public async Task<IdentityResult> RemoveUserRoleAsync(ApplicationUser user, string roleName)
		{
			return await userManager.RemoveFromRoleAsync(user, roleName);
		}

		public async Task<bool> IsUniqueUserName(string userName)
		{
			return !await userManager.Users.AnyAsync(u => u.UserName.Equals(userName));
		}
		public async Task<bool> IsUniqueEmail(string email)
		{
			return !await userManager.Users.AnyAsync(u => u.Email.Equals(email));
		}
	}
}
