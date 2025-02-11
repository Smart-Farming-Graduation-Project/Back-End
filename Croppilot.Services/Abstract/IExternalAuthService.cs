using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
    public interface IExternalAuthService
    {
        Task<ExternalAuthUserDTO?> VerifyFacebookToken(string accessToken);
        Task<ExternalAuthUserDTO?> VerifyGoogleTokenAsync(string accessToken);
        Task<bool?> GetUserByProviderAsync(string userId, string provider);
        Task<ApplicationUser?> GetUserById(string UserId);
        Task<IdentityResult?> CreateUser(ApplicationUser user);
    }

}
