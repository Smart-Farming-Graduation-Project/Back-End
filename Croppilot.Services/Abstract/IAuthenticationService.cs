using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Services.Abstract
{
	public interface IAuthenticationService
	{
		Task<ApplicationUser> GetUserById(string id);
		Task<ApplicationUser> GetUserByUserName(string userName);
		Task<ApplicationUser> GetUserByEmail(string email);
		Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
		Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
		Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
		Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
		Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
		Task<TokenResponse> GetJWTtoken(ApplicationUser user);
		Task<List<RefreshToken>> GetRefreshTokens();
		Task<TokenResponse> RefreshTokenAsync(ApplicationUser user, string refreshToken);
		Task<bool> RevokeRefreshTokenAsync(string refreshToken);

	}
}
