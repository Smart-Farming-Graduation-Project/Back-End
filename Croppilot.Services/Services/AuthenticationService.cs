using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Croppilot.Services.Services
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JwtSettings _jwtSettings;
		private readonly IUnitOfWork _unitOfWork;
		public AuthenticationService(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings, IUnitOfWork unitOfWork)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings;
			_unitOfWork = unitOfWork;
		}

		public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
		{
			return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
		}

		public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
		{
			return await _userManager.CheckPasswordAsync(user, password);
		}

		public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
		{
			return await _userManager.CreateAsync(user, password);
		}

		public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
		{
			return await _userManager.DeleteAsync(user);
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
				issuer: _jwtSettings.Issuer,
				expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenDurationInMinutes),
				signingCredentials: new SigningCredentials(
					new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key)),
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
					new Claim(ClaimTypes.NameIdentifier,user.UserName ?? string.Empty),
					new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
					new Claim(ClaimTypes.Email,user.Email ?? string.Empty)
				};
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
				ExpiresOn = DateTime.UtcNow.ToLocalTime().AddDays(_jwtSettings.RefreshTokenDurationInDays),
				CreatedOn = DateTime.UtcNow.ToLocalTime(),
				UserId = user.Id
			};
			refreshToken = await _unitOfWork.RefreshTokenRepository.AddAsync(refreshToken);
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
			var token = await _unitOfWork.RefreshTokenRepository.GetAsync(r => r.Token.Equals(refreshToken));
			if (token is null || !token.IsActive) return await Task.FromResult(false);
			token.RevokedOn = DateTime.UtcNow.ToLocalTime();
			await _unitOfWork.RefreshTokenRepository.UpdateAsync(token);
			return await Task.FromResult(true);
		}

		public async Task<ApplicationUser> GetUserByEmail(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<ApplicationUser> GetUserById(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<ApplicationUser> GetUserByUserName(string userName)
		{
			return await _userManager.Users.Include(u => u.RefreshTokens).Where(u => u.UserName.Equals(userName)).FirstOrDefaultAsync();
			//return await _userManager.FindByNameAsync(userName);
		}

		public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
		{
			return await _userManager.UpdateAsync(user);
		}



		//private async Task<List<RefreshToken>> GetRefreshTokensBelongToUserAsync(string userId)
		//{
		//	return await _unitOfWork.RefreshTokenRepository.GetAllAsync(r => r.UserId.Equals(userId));
		//}

		public async Task<List<RefreshToken>> GetRefreshTokens()
		{
			return await _unitOfWork.RefreshTokenRepository.GetAllAsync();
		}

	}
}
