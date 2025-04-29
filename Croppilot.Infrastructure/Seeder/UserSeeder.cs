using Croppilot.Date.Enum;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Croppilot.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            var options = configuration.GetSection("SeedUsers").Get<SeedUserOptions>();

            if (!(await userManager.Users.CountAsync() > 0))
            {
                var owner = new ApplicationUser()
                {
                    FirstName = "default",
                    LastName = "Manager",
                    UserName = "Manager",
                    Email = options.Manager.Email,
                    Address = "Cairo",
                    Phone = "0100000000",
                    ImageUrl = "https://example.com/image.jpg",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(owner, options.Manager.Password);
                await userManager.AddToRoleAsync(owner, UserRoleEnum.Manager.ToString());
                await userManager.AddToRoleAsync(owner, UserRoleEnum.Admin.ToString());
                await userManager.AddToRoleAsync(owner, UserRoleEnum.User.ToString());
                await userManager.AddToRoleAsync(owner, UserRoleEnum.Buyer.ToString());
                await userManager.AddToRoleAsync(owner, UserRoleEnum.Farmer.ToString());

                var frontAdmin = new ApplicationUser
                {
                    FirstName = "abdo",
                    LastName = "admin",
                    UserName = "admin",
                    Email = options.FrontAdmin.Email,
                    Address = "cairo",
                    Phone = "01000000000",
                    ImageUrl = "https://example.com/image.jpg",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(frontAdmin, options.FrontAdmin.Password);
                await userManager.AddToRoleAsync(frontAdmin, UserRoleEnum.Admin.ToString());
                await userManager.AddToRoleAsync(frontAdmin, UserRoleEnum.User.ToString());
                await userManager.AddToRoleAsync(frontAdmin, UserRoleEnum.Farmer.ToString());

                var frontUser = new ApplicationUser
                {
                    FirstName = "abdo",
                    LastName = "user",
                    UserName = "user",
                    Email = options.FrontUser.Email,
                    Address = "cairo",
                    Phone = "0100000000",
                    ImageUrl = "https://example.com/image.jpg",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(frontUser, options.FrontUser.Password);
                await userManager.AddToRoleAsync(frontUser, UserRoleEnum.User.ToString());
                await userManager.AddToRoleAsync(frontUser, UserRoleEnum.Buyer.ToString());

                var mobileAdmin = new ApplicationUser
                {
                    FirstName = "mobile",
                    LastName = "admin",
                    UserName = "mobileadmin",
                    Email = options.MobileAdmin.Email,
                    Address = "Cairo",
                    Phone = "01000000000",
                    ImageUrl = "https://example.com/mobile.jpg",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(mobileAdmin, options.MobileAdmin.Password);
                await userManager.AddToRoleAsync(mobileAdmin, UserRoleEnum.User.ToString());
                await userManager.AddToRoleAsync(mobileAdmin, UserRoleEnum.Admin.ToString());
                await userManager.AddToRoleAsync(mobileAdmin, UserRoleEnum.Farmer.ToString());

                var mobileUser = new ApplicationUser
                {
                    FirstName = "mobile",
                    LastName = "user",
                    UserName = "mobileuser",
                    Email = options.MobileUser.Email,
                    Address = "Cairo",
                    Phone = "01000000000",
                    ImageUrl = "https://example.com/mobile.jpg",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(mobileUser, options.MobileUser.Password);
                await userManager.AddToRoleAsync(mobileUser, UserRoleEnum.User.ToString());
                await userManager.AddToRoleAsync(mobileUser, UserRoleEnum.Buyer.ToString());
            }
        }
    }
}
