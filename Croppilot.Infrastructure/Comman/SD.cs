namespace Croppilot.Infrastructure.Comman
{
    public static class SD
    {
        // Roles
        public const string AdminRole = "Admin";
        public const string ManagerRole = "Manager";
        public const string UserRole = "User";


        public const int MaximumLoginAttempts = 5;
        public const string AdminUserName = "admin@example.com";

        //External Provider
        public const string Facebook = "facebook";
        public const string Google = "google";

        //Email Templetes 
        public const long ConfirmEmailTemplateId = 6754025;
        public const long ResetPasswordTemplateId = 6754405;
        public const long SendOtpTemplateId = 6754453;
    }
}
