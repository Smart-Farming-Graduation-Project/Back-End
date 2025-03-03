using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Croppilot.Services.Services
{
    public class ExternalAuthService : IExternalAuthService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _facebookHttpClient;
        private readonly UserManager<ApplicationUser> _userManager;
        public ExternalAuthService(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _config = config;
            _userManager = userManager;
            _facebookHttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com")
            };
        }

        public async Task<bool> FacebookValidatedAsync(string accessToken, string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(userId))
                {
                    return false;
                }

                var appId = _config["Authentication:Facebook:AppId"];
                var appSecret = _config["Authentication:Facebook:AppSecret"];
                if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(appSecret))
                {
                    return false;
                }

                var facebookKeys = $"{appId}|{appSecret}";
                var fbResult = await _facebookHttpClient.GetFromJsonAsync<FacebookResultDto>(
                    $"debug_token?input_token={accessToken}&access_token={facebookKeys}");

                return fbResult?.Data?.Is_Valid == true && string.Equals(fbResult.Data.User_Id, userId, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                // Log the error properly (e.g., using a logging framework)
                Console.WriteLine($"Facebook validation error: {ex.Message}");
                return false;
            }
        }



        public async Task<bool> GoogleValidatedAsync(string accessToken, string userId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);

            if (!payload.Audience.Equals(_config["Authentication:Google:ClientId"]))
            {
                return false;
            }

            if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
            {
                return false;
            }

            if (payload.ExpirationTimeSeconds == null)
            {
                return false;
            }

            DateTime now = DateTime.Now.ToUniversalTime();
            DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
            if (now > expiration)
            {
                return false;
            }

            if (!payload.Subject.Equals(userId))
            {
                return false;
            }

            return true;
        }


        public async Task<ApplicationUser?> GetUserByProviderAsync(string userId, string provider)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.UserName == userId && x.Provider == provider);

            return user;

        }

        public async Task<ApplicationUser?> GetUserById(string UserId)
        {
            return await _userManager.FindByNameAsync(UserId);
        }

        public async Task<IdentityResult?> CreateUser(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);
            return result;
        }
    }
}
