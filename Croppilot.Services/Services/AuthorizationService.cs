using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Croppilot.Services.Services
{
	internal class AuthorizationService : IAuthorizationService
	{
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly UserManager<ApplicationUser> _userManager;
		public AuthorizationService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async Task<IdentityResult> AssignRolesToUser(ApplicationUser user, List<string> roles)
		{
			return await _userManager.AddToRolesAsync(user, roles);
		}

		public async Task<IdentityResult> CreteRoleAsync(string roleName)
		{
			return await _roleManager.CreateAsync(new ApplicationRole(roleName.Trim()));
		}

		public async Task<IdentityResult> DeleteRoleAsync(ApplicationRole role)
		{
			return await _roleManager.DeleteAsync(role);
		}

		public async Task<IdentityResult> EditRoleAsync(ApplicationRole role, string newName)
		{
			role.Name = newName.Trim();
			return await _roleManager.UpdateAsync(role);
		}

		public async Task<ApplicationRole?> GetRoleByIdAsync(string id)
		{
			return await _roleManager.FindByIdAsync(id);
		}

		public async Task<ApplicationRole?> GetRoleByNameAsync(string roleName)
		{
			return await _roleManager.FindByNameAsync(roleName);
		}

		public async Task<List<ApplicationRole>> GetRolesAsync()
		{
			return await _roleManager.Roles.ToListAsync();
		}

		public async Task<bool> IsRoleExistAsync(string roleName)
		{
			return await _roleManager.RoleExistsAsync(roleName.Trim());
		}

		public async Task<bool> IsRoleFree(string roleName)
		{
			var users = await _userManager.GetUsersInRoleAsync(roleName.Trim());
			return !users.Any();
		}
	}
}
