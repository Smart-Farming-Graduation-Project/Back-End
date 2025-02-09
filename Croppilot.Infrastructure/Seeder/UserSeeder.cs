using Croppilot.Date.Enum;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Infrastructure.Seeder
{
	public static class UserSeeder
	{
		public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
		{
			if (!(await userManager.Users.CountAsync() > 0))
			{
				var user = new ApplicationUser()
				{
					FirstName = "default",
					LastName = "admin",
					UserName = "admin",
					Email = "admin@gmail.com",
					Address = "Zifta",
					Phone = "01234567890",
					EmailConfirmed = true
				};
				await userManager.CreateAsync(user, "Mo123#");
				await userManager.AddToRoleAsync(user, UserRoleEnum.Admin.ToString());
			}
		}
	}
}
