using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoverIdManualGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Rovers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 46, 7, 297, DateTimeKind.Utc).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 31, 7, 297, DateTimeKind.Utc).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 16, 7, 297, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 1, 1, 7, 297, DateTimeKind.Utc).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 0, 56, 7, 297, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 1, 11, 7, 297, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 1, 6, 7, 297, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 1, 13, 7, 297, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 1, 14, 7, 297, DateTimeKind.Utc).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 27, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 11, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 16, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 12, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 21, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 6, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 8, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1777), new DateTime(2025, 3, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1768) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1780), new DateTime(2025, 4, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 7, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1782), new DateTime(2025, 2, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1784), new DateTime(2025, 5, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1783) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1786), new DateTime(2025, 1, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1785) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 10, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1791), new DateTime(2024, 12, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1787) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1471), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1471) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1474), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1476), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1479), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1481), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1482) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1484), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1486), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1489), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1491), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1492) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1494), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1496), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1499), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1501), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1504), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1506), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1509), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1509) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1511), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1514), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1560), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1563), new DateTime(2025, 6, 26, 1, 16, 7, 297, DateTimeKind.Utc).AddTicks(1563) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Rovers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
        }
    }
}
