using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Croppilot.Services.Services
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JwtSettings _jwtSettings;
		public AuthenticationService(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings;
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

		public Task<string> GetJWTtoken(ApplicationUser user)
		{
			var jwtToken = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
				signingCredentials: new SigningCredentials(
					new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key)),
					SecurityAlgorithms.HmacSha256Signature
					),
				claims: new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier,user.UserName ?? string.Empty),
					new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
					new Claim(ClaimTypes.Email,user.Email ?? string.Empty)
				}
				);
			var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
			return Task.FromResult(token);
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
			return await _userManager.FindByNameAsync(userName);
		}

		public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
		{
			return await _userManager.UpdateAsync(user);
		}
	}
}
