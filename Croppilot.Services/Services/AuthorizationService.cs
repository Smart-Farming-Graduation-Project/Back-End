using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Croppilot.Services.Services;

internal class AuthorizationService(
    RoleManager<ApplicationRole> roleManager,
    UserManager<ApplicationUser> userManager)
    : IAuthorizationService
{
    public async Task<IdentityResult> AssignRolesToUser(ApplicationUser user, List<string> roles)
    {
        return await userManager.AddToRolesAsync(user, roles);
    }

    public async Task<IdentityResult> CreteRoleAsync(string roleName)
    {
        return await roleManager.CreateAsync(new ApplicationRole(roleName.Trim()));
    }

    public async Task<IdentityResult> DeleteRoleAsync(ApplicationRole role)
    {
        return await roleManager.DeleteAsync(role);
    }

    public async Task<IdentityResult> EditRoleAsync(ApplicationRole role, string newName)
    {
        role.Name = newName.Trim();
        return await roleManager.UpdateAsync(role);
    }

    public async Task<ApplicationRole?> GetRoleByIdAsync(string id)
    {
        return await roleManager.FindByIdAsync(id);
    }

    public async Task<ApplicationRole?> GetRoleByNameAsync(string roleName)
    {
        return await roleManager.FindByNameAsync(roleName);
    }

    public async Task<List<ApplicationRole>> GetRolesAsync()
    {
        return await roleManager.Roles.ToListAsync();
    }

    public async Task<bool> IsRoleExistAsync(string roleName)
    {
        return await roleManager.RoleExistsAsync(roleName.Trim());
    }

    public async Task<bool> IsRoleFree(string roleName)
    {
        var users = await userManager.GetUsersInRoleAsync(roleName.Trim());
        return !users.Any();
    }
}