using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addalerts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmergencyAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergencyType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyAlerts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmergencyAlerts",
                columns: new[] { "Id", "CreatedAt", "EmergencyType", "Latitude", "LocationDescription", "Longitude", "Message", "Severity" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 25, 13, 3, 40, 593, DateTimeKind.Utc).AddTicks(2371), 5, 26.820553, "Farm Field #1", 30.802498, "Low moisture detected in Field A", 2 },
                    { 2, new DateTime(2025, 4, 25, 12, 48, 40, 593, DateTimeKind.Utc).AddTicks(2378), 4, 27.820553, "Farm Field #2", 31.802498, "Pest activity reported in Wheat field", 1 },
                    { 3, new DateTime(2025, 4, 25, 12, 33, 40, 593, DateTimeKind.Utc).AddTicks(2381), 0, 28.820553, "Farm Field #3", 32.802498, "Tractor requires maintenance", 0 },
                    { 4, new DateTime(2025, 4, 25, 13, 18, 40, 593, DateTimeKind.Utc).AddTicks(2382), 3, 29.820553, "Farm Field #4", 33.802498, "Storm warning for tonight", 2 },
                    { 5, new DateTime(2025, 4, 25, 13, 13, 40, 593, DateTimeKind.Utc).AddTicks(2384), 6, 30.820553, "Farm Field #5", 34.802498, "High pH level detected in Field B", 1 },
                    { 6, new DateTime(2025, 4, 25, 13, 28, 40, 593, DateTimeKind.Utc).AddTicks(2385), 5, 31.820553, "Farm Field #6", 35.802498, "Low moisture detected in Field C", 2 },
                    { 7, new DateTime(2025, 4, 25, 13, 23, 40, 593, DateTimeKind.Utc).AddTicks(2387), 4, 32.820552999999997, "Farm Field #7", 36.802498, "Pest activity reported in Corn field", 1 },
                    { 8, new DateTime(2025, 4, 25, 13, 30, 40, 593, DateTimeKind.Utc).AddTicks(2388), 1, 26.820553, "Farm Field #1", 30.802498, "Medical emergency: Worker injured in Field A", 2 },
                    { 9, new DateTime(2025, 4, 25, 13, 31, 40, 593, DateTimeKind.Utc).AddTicks(2390), 7, 27.820553, "Farm Entrance", 31.802498, "Unusual activity reported near the farm entrance", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergencyAlerts");
        }
    }
}
