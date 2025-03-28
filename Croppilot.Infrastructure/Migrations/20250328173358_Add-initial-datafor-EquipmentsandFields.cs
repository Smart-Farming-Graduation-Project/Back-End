using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddinitialdataforEquipmentsandFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Battery", "Connectivity", "EquipmentId", "HoursUsed", "LastMaintenance", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 85.0, 0, "EQ-001", 120.0, new DateTime(2025, 2, 26, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2477), "Tractor A", 0 },
                    { 2, 60.0, 1, "EQ-002", 50.0, new DateTime(2025, 3, 13, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2491), "Drone B", 2 },
                    { 3, 95.0, 0, "EQ-003", 30.0, new DateTime(2025, 3, 18, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2493), "Sprinkler C", 1 },
                    { 4, 75.0, 0, "EQ-004", 200.0, new DateTime(2025, 2, 11, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2495), "Harvester D", 0 },
                    { 5, 100.0, 1, "EQ-005", 20.0, new DateTime(2025, 3, 23, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2497), "Seeder E", 2 },
                    { 6, 50.0, 0, "EQ-006", 90.0, new DateTime(2025, 3, 8, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2498), "Plow F", 1 }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Crop", "HarvestDate", "Irrigation", "Name", "PlantingDate", "Size", "Status" },
                values: new object[,]
                {
                    { 1, "Wheat", new DateTime(2025, 5, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2527), 1, "Field Alpha", new DateTime(2024, 12, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2523), 10.5, 2 },
                    { 2, "Corn", new DateTime(2025, 6, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2532), 2, "Field Beta", new DateTime(2025, 1, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2531), 15.199999999999999, 2 },
                    { 3, "Rice", new DateTime(2025, 4, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2534), 3, "Field Gamma", new DateTime(2024, 11, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2533), 8.0, 2 },
                    { 4, "Soybeans", new DateTime(2025, 8, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2536), 1, "Field Delta", new DateTime(2025, 2, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2536), 12.699999999999999, 4 },
                    { 5, "Barley", new DateTime(2025, 6, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2539), 5, "Field Epsilon", new DateTime(2024, 10, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2538), 20.300000000000001, 2 },
                    { 6, "Oats", new DateTime(2025, 7, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2541), 4, "Field Zeta", new DateTime(2024, 9, 28, 17, 33, 58, 300, DateTimeKind.Utc).AddTicks(2540), 9.5, 3 }
                });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6);


        }
    }
}
