using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
    public interface IExternalAuthService
    {
        Task<bool> FacebookValidatedAsync(string accessToken, string userId);
        Task<bool> GoogleValidatedAsync(string accessToken, string userId);
        Task<ApplicationUser?> GetUserByProviderAsync(string userId, string provider);
        Task<ApplicationUser?> GetUserById(string UserId);
        Task<IdentityResult?> CreateUser(ApplicationUser user);
    }

}
