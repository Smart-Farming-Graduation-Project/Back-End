using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Croppilot.Date.Helpers.Dashboard.Enum;
using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class EquipmentSeed
    {
        public static void SeedEquipments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(
               new Equipment { Id = 1, EquipmentId = "EQ-001", Name = "Tractor A", Status = EquipmentStatus.Active, LastMaintenance = DateTime.UtcNow.AddDays(-30), HoursUsed = 120, Battery = 85, Connectivity = EquipmentConnectivity.Online },
               new Equipment { Id = 2, EquipmentId = "EQ-002", Name = "Drone B", Status = EquipmentStatus.Idle, LastMaintenance = DateTime.UtcNow.AddDays(-15), HoursUsed = 50, Battery = 60, Connectivity = EquipmentConnectivity.Offline },
               new Equipment { Id = 3, EquipmentId = "EQ-003", Name = "Sprinkler C", Status = EquipmentStatus.Maintenance, LastMaintenance = DateTime.UtcNow.AddDays(-10), HoursUsed = 30, Battery = 95, Connectivity = EquipmentConnectivity.Online },
               new Equipment { Id = 4, EquipmentId = "EQ-004", Name = "Harvester D", Status = EquipmentStatus.Active, LastMaintenance = DateTime.UtcNow.AddDays(-45), HoursUsed = 200, Battery = 75, Connectivity = EquipmentConnectivity.Online },
               new Equipment { Id = 5, EquipmentId = "EQ-005", Name = "Seeder E", Status = EquipmentStatus.Idle, LastMaintenance = DateTime.UtcNow.AddDays(-5), HoursUsed = 20, Battery = 100, Connectivity = EquipmentConnectivity.Offline },
               new Equipment { Id = 6, EquipmentId = "EQ-006", Name = "Plow F", Status = EquipmentStatus.Maintenance, LastMaintenance = DateTime.UtcNow.AddDays(-20), HoursUsed = 90, Battery = 50, Connectivity = EquipmentConnectivity.Online }
             );
        }
    }
}
