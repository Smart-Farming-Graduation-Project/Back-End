﻿namespace Croppilot.Infrastructure.Comman
{
    public static class SD
    {
        // Roles
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


        //Weather API
        public const string WeatherAPIBase = "https://api.openweathermap.org/data/2.5";
        public const string DefaultCity = "Cairo";

        //soil
        public const double Longitude = 30.802498;
        public const double Latitude = 26.820553;

    }
}
