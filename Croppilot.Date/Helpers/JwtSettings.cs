namespace Croppilot.Date.Helpers
{
	public class JwtSettings
	{
		public string Issuer { get; set; }
		public bool ValidateAudience { get; set; }
		public bool ValidateIssuer { get; set; }
		public bool ValidateIssuerSigningKey { get; set; }
		public int DurationInMinutes { get; set; }
		public string Key { get; set; }
	}
}
