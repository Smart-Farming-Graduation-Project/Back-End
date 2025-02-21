namespace Croppilot.Date.Helpers
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public int AccessTokenDurationInMinutes { get; set; }
        public int RefreshTokenDurationInDays { get; set; }
        public string Key { get; set; }
    }
}
