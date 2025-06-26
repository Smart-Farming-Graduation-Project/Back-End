using Croppilot.Date.DTOS;
using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
			var jwtTokenId = Guid.NewGuid().ToString();
			var refreshToken = await GenerateRefreshTokenAsync(user, jwtTokenId);
			var accessToken = await CreateTokenAsync(user, refreshToken.JwtTokenId);
			return await Task.FromResult(new TokenResponse()
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken.Token,
				RefreshTokenExpiration = refreshToken.ExpiresOn
			});

		}


		public async Task<TokenResponse> RefreshTokenAsync(TokenDto tokenDto)
		{
			var response = new TokenResponse();
			var existingRefreshToken = await IsvalidRefreshToken(tokenDto.RefreshToken);
			if (existingRefreshToken is null)
			{
				response.RefreshToken = tokenDto.RefreshToken;
				return await Task.FromResult(response);
			}
			var userId = await IsValidAccessToken(existingRefreshToken, tokenDto.AccessToken);
			if (string.IsNullOrEmpty(userId))
			{
				await MarkAllTokenInChainAsInvalid(existingRefreshToken.JwtTokenId);
				response.RefreshToken = tokenDto.RefreshToken;
				return await Task.FromResult(response);
			}
			existingRefreshToken.RevokedOn = DateTime.UtcNow;
			var user = await userManager.FindByIdAsync(userId);
			if (user is null)
			{
				response.RefreshToken = tokenDto.RefreshToken;
				return await Task.FromResult(response);
			}
			var newRefreshToken = await GenerateRefreshTokenAsync(user, existingRefreshToken.JwtTokenId);
			response.AccessToken = await CreateTokenAsync(user, existingRefreshToken.JwtTokenId);
			response.RefreshToken = newRefreshToken.Token;
			response.RefreshTokenExpiration = newRefreshToken.ExpiresOn;
			return await Task.FromResult(response);
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

		public async Task<List<RefreshToken>> GetRefreshTokens()
		{
			return await unitOfWork.RefreshTokenRepository.GetAllAsync();
		}


		private async Task<string> CreateTokenAsync(ApplicationUser user, string jwtTokenId)
		{
			var jwtToken = new JwtSecurityToken(
				issuer: jwtSettings.Issuer,
				expires: DateTime.Now.AddMinutes(jwtSettings.AccessTokenDurationInMinutes),
				signingCredentials: new SigningCredentials(
					new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
					SecurityAlgorithms.HmacSha256Signature
					),
				claims: await GetClaimsAsync(user, jwtTokenId)
				);
			var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
			return await Task.FromResult(accessToken);
		}

		private async Task<List<Claim>> GetClaimsAsync(ApplicationUser user, string jwtTokenId)
		{
			var claims = new List<Claim>
				{
					new Claim(JwtRegisteredClaimNames.Sub,user.Id ?? string.Empty),
					new Claim(JwtRegisteredClaimNames.GivenName,user.UserName ?? string.Empty),
					new Claim(JwtRegisteredClaimNames.Email,user.Email ?? string.Empty),
					new Claim(JwtRegisteredClaimNames.Jti , jwtTokenId)
				};
			var roles = await userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(nameof(ClaimTypes.Role), role));
			}
			return await Task.FromResult(claims);
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

		private async Task MarkAllTokenInChainAsInvalid(string jwtTokenId)
		{
			await unitOfWork.RefreshTokenRepository.GetForPaginationAsync(r => r.JwtTokenId.Equals(jwtTokenId)).Result
				.ExecuteUpdateAsync(p => p.SetProperty(r => r.RevokedOn, DateTime.UtcNow));
		}

		//private async Task<bool> IsvalidRefreshToken(ApplicationUser user, string refreshToken)
		//{
		//	if (user.RefreshTokens is not null && user.RefreshTokens.Any(r => r.Token == refreshToken))
		//	{
		//		var userRefreshToken = user.RefreshTokens.First(r => r.Token == refreshToken);
		//		if (userRefreshToken.IsActive)
		//		{
		//			return await Task.FromResult(true);
		//		}
		//		await MarkAllTokenInChainAsInvalid(userRefreshToken.JwtTokenId);
		//	}
		//	return await Task.FromResult(false);
		//}

		private async Task<RefreshToken?> IsvalidRefreshToken(string refreshToken)
		{
			var token = await unitOfWork.RefreshTokenRepository.GetAsync(r => r.Token.Equals(refreshToken), tracked: true);
			if (token is not null)
			{
				if (token.IsActive)
				{
					return await Task.FromResult(token);
				}
				await MarkAllTokenInChainAsInvalid(token.JwtTokenId);
			}
			return null;
		}
		private async Task<RefreshToken> GenerateRefreshTokenAsync(ApplicationUser user, string jwtTokenId)
		{
			//user.RefreshTokens = await GetRefreshTokensBelongToUserAsync(user.Id);

			//if (user?.RefreshTokens?.Any(r => r.IsActive) == true)
			//{
			//	return await Task.FromResult(user.RefreshTokens.FirstOrDefault(r => r.IsActive));
			//}
			var refreshToken = new RefreshToken()
			{
				Token = await CreateRefreshTokenAsync(),
				ExpiresOn = DateTime.UtcNow.AddDays(jwtSettings.RefreshTokenDurationInDays),
				CreatedOn = DateTime.UtcNow,
				UserId = user.Id,
				JwtTokenId = jwtTokenId
			};
			refreshToken = await unitOfWork.RefreshTokenRepository.AddAsync(refreshToken);
			return await Task.FromResult(refreshToken);
		}

		private async Task<string> IsValidAccessToken(RefreshToken refreshToken, string accessToken)
		{
			var accessTokenData = ReadAccessToken(accessToken, validateLifeTime: false);
			return await Task.FromResult((accessTokenData.isSuccess && refreshToken.UserId == accessTokenData.userId && refreshToken.JwtTokenId == accessTokenData.jwtTokenId) ?
				accessTokenData.userId : string.Empty);
		}
		private (bool isSuccess, string userId, string jwtTokenId) ReadAccessToken(string accessToken, bool validateLifeTime = true)
		{
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			jwtSecurityTokenHandler.ValidateToken(accessToken,
				new TokenValidationParameters()
				{
					ValidateIssuer = jwtSettings.ValidateIssuer,
					ValidIssuers = new[] { jwtSettings.Issuer },
					ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
					ValidateAudience = jwtSettings.ValidateAudience,
					ValidateLifetime = validateLifeTime
				},
				out SecurityToken validatedToken
			);
			var jwtToken = validatedToken as JwtSecurityToken;
			if (jwtToken is null) return (false, string.Empty, string.Empty);
			var userId = jwtToken?.Claims?.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
			var jwtTokenId = jwtToken?.Claims?.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
			return (true, userId ?? string.Empty, jwtTokenId ?? string.Empty);
		}
		//private async Task<List<RefreshToken>> GetRefreshTokensBelongToUserAsync(string userId)
		//{
		//	return await _unitOfWork.RefreshTokenRepository.GetAllAsync(r => r.UserId.Equals(userId));
		//}



	}
}
