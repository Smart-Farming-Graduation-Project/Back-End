using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class addisfavoriteattribute : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "IsFavorite",
				table: "Products",
				type: "bit",
				nullable: false,
				defaultValue: false);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "IsFavorite",
				table: "Products");

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 1,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 18, 56, 657, DateTimeKind.Utc).AddTicks(2434));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 2,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 3, 56, 657, DateTimeKind.Utc).AddTicks(2436));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 3,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 20, 48, 56, 657, DateTimeKind.Utc).AddTicks(2438));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 4,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 33, 56, 657, DateTimeKind.Utc).AddTicks(2452));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 5,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 28, 56, 657, DateTimeKind.Utc).AddTicks(2454));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 6,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 43, 56, 657, DateTimeKind.Utc).AddTicks(2455));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 7,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 38, 56, 657, DateTimeKind.Utc).AddTicks(2457));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 8,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 45, 56, 657, DateTimeKind.Utc).AddTicks(2458));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 9,
				column: "CreatedAt",
				value: new DateTime(2025, 4, 29, 21, 46, 56, 657, DateTimeKind.Utc).AddTicks(2460));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 1,
				column: "LastMaintenance",
				value: new DateTime(2025, 3, 30, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2297));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 2,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 14, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2313));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 3,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 19, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2315));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 4,
				column: "LastMaintenance",
				value: new DateTime(2025, 3, 15, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2316));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 5,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 24, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2318));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 6,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 9, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2320));

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 6, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2357), new DateTime(2025, 1, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2350) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 7, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2361), new DateTime(2025, 2, 28, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2360) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 5, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2364), new DateTime(2024, 12, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2362) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 9, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2366), new DateTime(2025, 3, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2365) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 7, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2368), new DateTime(2024, 11, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2367) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 8, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2370), new DateTime(2024, 10, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2369) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2080), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2081) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2083), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2084) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2086), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2086) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2089), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2089) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2092), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2092) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2094), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2095) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 7,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2097), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2097) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 8,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2099), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2099) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 9,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2102), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2102) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 10,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2104), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2104) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 11,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2106), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2107) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 12,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2109), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2109) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 13,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2112), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2112) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 14,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2114), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2115) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 15,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2117), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2117) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 16,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2119), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2120) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 17,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2122), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2122) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 18,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2124) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 19,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2126), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2127) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 20,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2129), new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2129) });
		}
	}
}
