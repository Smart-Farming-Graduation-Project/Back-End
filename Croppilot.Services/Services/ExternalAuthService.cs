using Croppilot.Date.DTOS;
using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;

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

                return fbResult?.Data?.Is_Valid == true &&
                       string.Equals(fbResult.Data.User_Id, userId, StringComparison.OrdinalIgnoreCase);
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
            try
            {
                using var httpClient = new HttpClient();

                var response = await httpClient.GetAsync(
                    $"https://www.googleapis.com/oauth2/v3/tokeninfo?access_token={Uri.EscapeDataString(accessToken)}");

                if (!response.IsSuccessStatusCode)
                {
                    //Console.WriteLine($"Google tokeninfo request failed: {response.StatusCode} - {response.ReasonPhrase}");
                    return false;
                }

                var jsonContent = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"Google tokeninfo response: {jsonContent}");

                if (string.IsNullOrEmpty(jsonContent))
                {
                    //Console.WriteLine("Empty response from Google tokeninfo");
                    return false;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var tokenInfo = System.Text.Json.JsonSerializer.Deserialize<GoogleTokenInfoResponse>(jsonContent, options);

                if (tokenInfo == null)
                {
                    //Console.WriteLine("Failed to deserialize Google tokeninfo response");
                    return false;
                }

                //Console.WriteLine($"Deserialized tokeninfo - UserId: {tokenInfo.UserId}, Audience: {tokenInfo.Audience}");

                var clientId = _config["Authentication:Google:ClientId"];
                if (string.IsNullOrEmpty(tokenInfo.Audience) || !tokenInfo.Audience.Equals(clientId))
                {
                    //Console.WriteLine($"Audience mismatch - Expected: {clientId}, Actual: {tokenInfo.Audience}");
                    return false;
                }

                if (string.IsNullOrEmpty(tokenInfo.UserId) || !tokenInfo.UserId.Equals(userId))
                {
                    //Console.WriteLine($"UserId mismatch - Expected: {userId}, Actual: {tokenInfo.UserId}");
                    return false;
                }

                // Check expiration using the new GetExpiresIn method
                int expiresIn = tokenInfo.GetExpiresIn();
                if (expiresIn <= 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log the full exception details
                //Console.WriteLine($"Google validation error: {ex.Message}");
                //Console.WriteLine($"Stack trace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }

                return false;
            }

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
