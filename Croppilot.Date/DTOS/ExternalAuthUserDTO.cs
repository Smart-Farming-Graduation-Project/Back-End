namespace Croppilot.Date.DTOS
{
    public class ExternalAuthUserDTO
    {
        public string Provider { get; set; } = string.Empty;
        public string IdToken { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // User's email
        public string Name { get; set; } = string.Empty;
    }

}
