using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
    public interface IExternalAuthService
    {
        Task<bool> ValidateFacebookTokenAsync(string accessToken, string userId);
        Task<bool> ValidateGoogleTokenAsync(string accessToken, string userId);
        Task<bool?> GetUserByProviderAsync(string userId, string provider);
        Task<ApplicationUser?> GetUserById(string UserId);
        Task<IdentityResult?> CreateUser(ApplicationUser user);
    }

}
