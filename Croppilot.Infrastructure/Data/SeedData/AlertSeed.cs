using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class AlertSeed
    {
        public static void SeedAlerts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>().HasData(
             new Alert
             {
                 Id = 1,
                 EmergencyType = EmergencyType.Irrigation,
                 Message = "Low moisture detected in Field A",
                 Severity = SeverityType.High,
                 Latitude = 26.820553,
                 Longitude = 30.802498,
                 LocationDescription = "Farm Field #1",
                 CreatedAt = DateTime.UtcNow.AddMinutes(-30)
             },
           new Alert
           {
               Id = 2,
               EmergencyType = EmergencyType.Pest,
               Message = "Pest activity reported in Wheat field",
               Severity = SeverityType.Medium,
               Latitude = 27.820553,
               Longitude = 31.802498,
               LocationDescription = "Farm Field #2",
               CreatedAt = DateTime.UtcNow.AddMinutes(-45)
           },
           new Alert
           {
               Id = 3,
               EmergencyType = EmergencyType.EquipmentFailure,
               Message = "Tractor requires maintenance",
               Severity = SeverityType.Low,
               Latitude = 28.820553,
               Longitude = 32.802498,
               LocationDescription = "Farm Field #3",
               CreatedAt = DateTime.UtcNow.AddMinutes(-60)
           },
           new Alert
           {
               Id = 4,
               EmergencyType = EmergencyType.SevereWeather,
               Message = "Storm warning for tonight",
               Severity = SeverityType.High,
               Latitude = 29.820553,
               Longitude = 33.802498,
               LocationDescription = "Farm Field #4",
               CreatedAt = DateTime.UtcNow.AddMinutes(-15)
           },
           new Alert
           {
               Id = 5,
               EmergencyType = EmergencyType.Soil,
               Message = "High pH level detected in Field B",
               Severity = SeverityType.Medium,
               Latitude = 30.820553,
               Longitude = 34.802498,
               LocationDescription = "Farm Field #5",
               CreatedAt = DateTime.UtcNow.AddMinutes(-20)
           },
           new Alert
           {
               Id = 6,
               EmergencyType = EmergencyType.Irrigation,
               Message = "Low moisture detected in Field C",
               Severity = SeverityType.High,
               Latitude = 31.820553,
               Longitude = 35.802498,
               LocationDescription = "Farm Field #6",
               CreatedAt = DateTime.UtcNow.AddMinutes(-5)
           },
           new Alert
           {
               Id = 7,
               EmergencyType = EmergencyType.Pest,
               Message = "Pest activity reported in Corn field",
               Severity = SeverityType.Medium,
               Latitude = 32.820553,
               Longitude = 36.802498,
               LocationDescription = "Farm Field #7",
               CreatedAt = DateTime.UtcNow.AddMinutes(-10)
           }, new Alert
           {
               Id = 8,
               EmergencyType = EmergencyType.MedicalEmergency,
               Message = "Medical emergency: Worker injured in Field A",
               Severity = SeverityType.High,
               Latitude = 26.820553,
               Longitude = 30.802498,
               LocationDescription = "Farm Field #1",
               CreatedAt = DateTime.UtcNow.AddMinutes(-3)
           },
           new Alert
           {
               Id = 9,
               EmergencyType = EmergencyType.Other,  // This will match "other"
               Message = "Unusual activity reported near the farm entrance",
               Severity = SeverityType.Low,
               Latitude = 27.820553,
               Longitude = 31.802498,
               LocationDescription = "Farm Entrance",
               CreatedAt = DateTime.UtcNow.AddMinutes(-2)
           });
        }
    }
}

