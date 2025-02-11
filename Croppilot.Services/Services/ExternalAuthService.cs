using Croppilot.Date.DTOS;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Croppilot.Services.Services
{
    public class ExternalAuthService(HttpClient httpClient, IConfiguration config, UserManager<ApplicationUser?> userManager) : IExternalAuthService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _config = config;



        public async Task<ExternalAuthUserDTO?> VerifyFacebookToken(string token)
        {
            var client = new RestClient($"https://graph.facebook.com/me?fields=id,email,name&access_token={token}");
            var request = new RestRequest();
            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return null;

            var facebookUser = JsonSerializer.Deserialize<ExternalAuthUserDTO>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            //return new ExternalAuthUserDTO
            //{
            //    Email = facebookUser.GetProperty("email").GetString(),
            //    FirstName = facebookUser.GetProperty("first_name").GetString(),
            //    LastName = facebookUser.GetProperty("last_name").GetString()
            //};

            return facebookUser;
        }


        public async Task<ExternalAuthUserDTO?> VerifyGoogleTokenAsync(string token)
        {
            var client = new RestClient($"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={token}");
            var request = new RestRequest();
            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return null;

            var googleUser = JsonSerializer.Deserialize<ExternalAuthUserDTO>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            //return new ExternalAuthUserDTO
            //{
            //    Email = googleUser.GetProperty("email").GetString(),
            //    FirstName = googleUser.GetProperty("given_name").GetString(),
            //    LastName = googleUser.GetProperty("family_name").GetString()
            //   UserName = Email.Split('@')[0] // Extracts the username from email
            //};

            return googleUser;
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
