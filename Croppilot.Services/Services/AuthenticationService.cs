using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Croppilot.Services.Services
{
    internal class AuthenticationService(
        UserManager<ApplicationUser> userManager,
        JwtSettings jwtSettings,
        IUnitOfWork unitOfWork)
        : IAuthenticationService
    {
        public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            return await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded) return result;
            return await userManager.AddToRoleAsync(user, UserRoleEnum.User.ToString());
        }


        public async Task<TokenResponse> GetJWTtoken(ApplicationUser user)
        {
            var accessToken = await CreateTokenAsync(user);
            var refreshToken = await GenerateRefreshTokenAsync(user);
            return await Task.FromResult(new TokenResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn
            });

        }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var jwtToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience, // Add Audience
                expires: DateTime.Now.AddMinutes(jwtSettings.AccessTokenDurationInMinutes),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                claims: await GetClaimsAsync(user)
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return await Task.FromResult(accessToken);
        }

        private async Task<List<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
                {
                    new Claim("Id", user.Id),
                    new Claim(ClaimTypes.NameIdentifier,user.UserName ?? string.Empty),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
                };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(nameof(ClaimTypes.Role), role));
            }
            return await Task.FromResult(claims);
        }


        public async Task<TokenResponse> RefreshTokenAsync(ApplicationUser user, string refreshToken)
        {
            var response = new TokenResponse();
            if (!await IsvalidRefreshToken(user, refreshToken))
            {
                response.RefreshToken = refreshToken;
                return await Task.FromResult(response);
            }
            var userRefreshToken = user.RefreshTokens.First(r => r.Token == refreshToken);
            userRefreshToken.RevokedOn = DateTime.UtcNow.ToLocalTime();
            var newRefreshToken = await GenerateRefreshTokenAsync(user);
            response.AccessToken = await CreateTokenAsync(user);
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.ExpiresOn;
            return await Task.FromResult(response);
        }

        private async Task<bool> IsvalidRefreshToken(ApplicationUser user, string refreshToken)
        {
            if (user.RefreshTokens is not null && user.RefreshTokens.Any(r => r.Token == refreshToken))
            {
                var userRefreshToken = user.RefreshTokens.First(r => r.Token == refreshToken);
                if (userRefreshToken.IsActive)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(false);
        }
        private async Task<RefreshToken> GenerateRefreshTokenAsync(ApplicationUser user)
        {
            //user.RefreshTokens = await GetRefreshTokensBelongToUserAsync(user.Id);

            if (user?.RefreshTokens?.Any(r => r.IsActive) == true)
            {
                return await Task.FromResult(user.RefreshTokens.FirstOrDefault(r => r.IsActive));
            }
            var refreshToken = new RefreshToken()
            {
                Token = await CreateRefreshTokenAsync(),
                ExpiresOn = DateTime.UtcNow.ToLocalTime().AddDays(jwtSettings.RefreshTokenDurationInDays),
                CreatedOn = DateTime.UtcNow.ToLocalTime(),
                UserId = user.Id
            };
            refreshToken = await unitOfWork.RefreshTokenRepository.AddAsync(refreshToken);
            return await Task.FromResult(refreshToken);
        }


        private async Task<string> CreateRefreshTokenAsync()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return await Task.FromResult(Convert.ToBase64String(randomNumber));
            }

        }

        public async Task<bool> RevokeRefreshTokenAsync(string refreshToken)
        {
            var token = await unitOfWork.RefreshTokenRepository.GetAsync(r => r.Token.Equals(refreshToken));
            if (token is null || !token.IsActive) return await Task.FromResult(false);
            token.RevokedOn = DateTime.UtcNow.ToLocalTime();
            await unitOfWork.RefreshTokenRepository.UpdateAsync(token);
            return await Task.FromResult(true);
        }

        public async Task<string?> CheckAndHandleLockoutAsync(ApplicationUser user)
        {
            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.UtcNow)
            {
                return $"Your account has been locked until {user.LockoutEnd.Value:yyyy-MM-dd HH:mm:ss} UTC.";
            }
            return null;
        }

        public async Task HandleFailedLoginAsync(ApplicationUser user)
        {
            if (!user.UserName.Equals(SD.AdminUserName))
            {
                await userManager.AccessFailedAsync(user);
            }

            if (user.AccessFailedCount >= SD.MaximumLoginAttempts)
            {
                var lockoutEnd = DateTime.UtcNow.AddDays(1);
                await userManager.SetLockoutEndDateAsync(user, lockoutEnd);
            }
        }

        public async Task ResetFailedAttemptsAsync(ApplicationUser user)
        {
            await userManager.ResetAccessFailedCountAsync(user);
            await userManager.SetLockoutEndDateAsync(user, null);
        }




        //private async Task<List<RefreshToken>> GetRefreshTokensBelongToUserAsync(string userId)
        //{
        //	return await _unitOfWork.RefreshTokenRepository.GetAllAsync(r => r.UserId.Equals(userId));
        //}


        public async Task<List<RefreshToken>> GetRefreshTokens()
        {
            return await unitOfWork.RefreshTokenRepository.GetAllAsync();
        }

    }
}
