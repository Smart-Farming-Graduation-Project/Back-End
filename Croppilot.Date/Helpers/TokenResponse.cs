﻿namespace Croppilot.Date.Helpers
{
	public class TokenResponse
	{
		public string? AccessToken { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiration { get; set; }
	}
}
