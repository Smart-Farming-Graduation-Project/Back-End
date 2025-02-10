using Croppilot.Date.Enum;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
        {
            if (!(await roleManager.Roles.CountAsync() > 0))
            {
                await roleManager.CreateAsync(new ApplicationRole(UserRoleEnum.Admin.ToString()));
                await roleManager.CreateAsync(new ApplicationRole(UserRoleEnum.User.ToString()));
                await roleManager.CreateAsync(new ApplicationRole(UserRoleEnum.Buyer.ToString()));
                await roleManager.CreateAsync(new ApplicationRole(UserRoleEnum.Seller.ToString()));

            }
        }
    }
}
