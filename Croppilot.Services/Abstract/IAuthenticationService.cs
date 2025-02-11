using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
    public interface IAuthenticationService
    {

        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<TokenResponse> GetJWTtoken(ApplicationUser user);
        Task<List<RefreshToken>> GetRefreshTokens();
        Task<TokenResponse> RefreshTokenAsync(ApplicationUser user, string refreshToken);
        Task<bool> RevokeRefreshTokenAsync(string refreshToken);


        Task<string?> CheckAndHandleLockoutAsync(ApplicationUser user);
        Task HandleFailedLoginAsync(ApplicationUser user);
        Task ResetFailedAttemptsAsync(ApplicationUser user);



    }
}
