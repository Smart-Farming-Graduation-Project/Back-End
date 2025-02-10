using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Croppilot.Services.Services
{
	internal class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<ApplicationUser> GetUserByEmail(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<ApplicationUser> GetUserById(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<ApplicationUser> GetUserByUserName(string userName)
		{
			return await _userManager.Users.Include(u => u.RefreshTokens).Where(u => u.UserName.Equals(userName)).FirstOrDefaultAsync();
			//return await _userManager.FindByNameAsync(userName);
		}

		public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
		{
			return await _userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
		{
			return await _userManager.DeleteAsync(user);
		}

		public async Task<bool> IsUserAssignedToRole(ApplicationUser user, string role)
		{
			return await _userManager.IsInRoleAsync(user, role);
		}

		public async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
		{
			return (await _userManager.GetRolesAsync(user)).ToList();
		}

		public async Task<IdentityResult> ChangeUserRole(ApplicationUser user, string roleName, string newRoleName)
		{
			var result = await _userManager.RemoveFromRoleAsync(user, roleName);
			if (!result.Succeeded) return result;
			return await _userManager.AddToRoleAsync(user, newRoleName);
		}

		public async Task<List<ApplicationUser>> GetUsersAssignedToRole(string roleName)
		{
			return (await _userManager.GetUsersInRoleAsync(roleName)).ToList();
		}

		public async Task<IdentityResult> RemoveUserRoleAsync(ApplicationUser user, string roleName)
		{
			return await _userManager.RemoveFromRoleAsync(user, roleName);
		}
	}
}
