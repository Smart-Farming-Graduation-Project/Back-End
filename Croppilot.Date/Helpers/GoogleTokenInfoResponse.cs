using System.Text.Json.Serialization;

namespace Croppilot.Date.Helpers
{
    public class GoogleTokenInfoResponse
    {
        [JsonPropertyName("azp")]
        public string? Audience { get; set; }

        [JsonPropertyName("aud")]
        public string? ClientId { get; set; }

        [JsonPropertyName("sub")]
        public string? UserId { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        [JsonPropertyName("exp")]
        public string? ExpirationTime { get; set; }

        [JsonPropertyName("expires_in")]
        public string? ExpiresInString { get; set; }

        public int GetExpiresIn()
        {
            if (int.TryParse(ExpiresInString, out int result))
            {
                return result;
            }
            return 0;
        }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("email_verified")]
        public string? EmailVerifiedString { get; set; }

        public bool IsEmailVerified()
        {
            if (bool.TryParse(EmailVerifiedString, out bool result))
            {
                return result;
            }
            return false;
        }

        [JsonPropertyName("access_type")]
        public string? AccessType { get; set; }
    }
}
