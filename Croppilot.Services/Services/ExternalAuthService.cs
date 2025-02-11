using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Croppilot.Services.Services
{
    public class ExternalAuthService(HttpClient httpClient, IConfiguration config, UserManager<ApplicationUser?> userManager) : IExternalAuthService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _config = config;



        public async Task<bool> ValidateFacebookTokenAsync(string accessToken, string userId)
        {
            var facebookKeys = $"{_config["Facebook:AppId"]}|{_config["Facebook:AppSecret"]}";
            var fbResult = await _httpClient.GetFromJsonAsync<FacebookResultDto>(
                $"debug_token?input_token={accessToken}&access_token={facebookKeys}"
            );

            return fbResult?.Data?.Is_Valid == true && fbResult.Data.User_Id == userId;
        }


        public async Task<bool> ValidateGoogleTokenAsync(string accessToken, string userId)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);
                var isValidIssuer = payload.Issuer == "accounts.google.com" || payload.Issuer == "https://accounts.google.com";
                var isTokenExpired = DateTime.UtcNow > DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).UtcDateTime;

                return payload.Audience == _config["Google:ClientId"] && isValidIssuer && !isTokenExpired && payload.Subject == userId;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool?> GetUserByProviderAsync(string userId, string provider)
        {
            var user = await userManager.Users
                .FirstOrDefaultAsync(x => x.UserName == userId && x.Provider == provider);

            if (user == null)
            {
                return false;
            }
            return true;

        }

        public async Task<ApplicationUser?> GetUserById(string UserId)
        {
            return await userManager.FindByNameAsync(UserId);
        }

        public async Task<IdentityResult?> CreateUser(ApplicationUser user)
        {
            var result = await userManager.CreateAsync(user);
            return result;
        }
    }
}
