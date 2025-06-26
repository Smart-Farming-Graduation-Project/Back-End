using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoverTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rovers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rovers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 27, 37, 454, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 12, 37, 454, DateTimeKind.Utc).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 25, 23, 57, 37, 454, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 42, 37, 454, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 37, 37, 454, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 52, 37, 454, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 47, 37, 454, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 54, 37, 454, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 55, 37, 454, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 27, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 11, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 16, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 12, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 21, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 6, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 8, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6673), new DateTime(2025, 3, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6668) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6676), new DateTime(2025, 4, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 7, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6678), new DateTime(2025, 2, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 11, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6680), new DateTime(2025, 5, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6682), new DateTime(2025, 1, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6681) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 10, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6685), new DateTime(2024, 12, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6683) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6428), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6429) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6432), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6432) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6434), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6437), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6440), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6442), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6442) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6444), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6445) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6447), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6450), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6452), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6453) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6455), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6455) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6457), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6460), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6462), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6463) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6465), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6467), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6468) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6470), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6473), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6473) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6475), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6475) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6478), new DateTime(2025, 6, 26, 0, 57, 37, 454, DateTimeKind.Utc).AddTicks(6478) });

            migrationBuilder.CreateIndex(
                name: "IX_Rovers_UserId",
                table: "Rovers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rovers");

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 10, 23, 680, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 15, 55, 23, 680, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 15, 40, 23, 680, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 25, 23, 680, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 20, 23, 680, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 35, 23, 680, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 30, 23, 680, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 37, 23, 680, DateTimeKind.Utc).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 16, 38, 23, 680, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 25, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 9, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 14, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 10, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 19, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 4, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 8, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5552), new DateTime(2025, 3, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5546) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5554), new DateTime(2025, 4, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5554) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 7, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5556), new DateTime(2025, 2, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 11, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5558), new DateTime(2025, 5, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5558) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5560), new DateTime(2025, 1, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 10, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5563), new DateTime(2024, 12, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5294), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5299), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5301), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5302) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5304), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5304) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5306), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5309), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5309) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5311), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5314), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5314) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5316), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5317) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5319), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5321), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5321) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5323), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5326), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5328), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5329) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5331), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5333), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5335), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5336) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5338), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5340), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5343), new DateTime(2025, 6, 24, 16, 40, 23, 680, DateTimeKind.Utc).AddTicks(5343) });
        }
    }
}
