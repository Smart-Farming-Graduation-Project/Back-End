namespace Croppilot.Infrastructure.Comman
{
    public class SeedUserOptions
    {
        public UserCredential Manager { get; set; }
        public UserCredential FrontAdmin { get; set; }
        public UserCredential FrontUser { get; set; }
        public UserCredential MobileAdmin { get; set; }
        public UserCredential MobileUser { get; set; }
    }
    public class UserCredential
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
