using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRatingToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Review_Rating",
                table: "Reviews");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Reviews",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 11, 57, 13, 537, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 11, 42, 13, 537, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 11, 27, 13, 537, DateTimeKind.Utc).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 12, 12, 13, 537, DateTimeKind.Utc).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 12, 7, 13, 537, DateTimeKind.Utc).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 12, 22, 13, 537, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 12, 17, 13, 537, DateTimeKind.Utc).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 12, 24, 13, 537, DateTimeKind.Utc).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 26, 12, 25, 13, 537, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 27, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 11, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 16, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastMaintenance",
                value: new DateTime(2025, 5, 12, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 21, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastMaintenance",
                value: new DateTime(2025, 6, 6, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 8, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9710), new DateTime(2025, 3, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9712), new DateTime(2025, 4, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 7, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9714), new DateTime(2025, 2, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 11, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9716), new DateTime(2025, 5, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 9, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9718), new DateTime(2025, 1, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9718) });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2025, 10, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9723), new DateTime(2024, 12, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9357), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9422), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9423) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9425), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9427), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9430), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9432), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9435), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9435) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9437), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9440), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9442), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9445), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9447), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9448) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9450), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9452), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9453) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9455), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9457), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9459), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9462), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9464), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9465) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9467), new DateTime(2025, 6, 26, 12, 27, 13, 537, DateTimeKind.Utc).AddTicks(9467) });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Review_Rating",
                table: "Reviews",
                sql: "[Rating] BETWEEN 1.0 AND 5.0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Review_Rating",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

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

            migrationBuilder.AddCheckConstraint(
                name: "CK_Review_Rating",
                table: "Reviews",
                sql: "[Rating] BETWEEN 1 AND 5");
        }
    }
}
