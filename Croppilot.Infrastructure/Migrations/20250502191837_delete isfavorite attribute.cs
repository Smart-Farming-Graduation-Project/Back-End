using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class deleteisfavoriteattribute : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "IsFavorite",
				table: "Products");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "IsFavorite",
				table: "Products",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 1,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 3, 4, 85, DateTimeKind.Utc).AddTicks(7314));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 2,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 16, 48, 4, 85, DateTimeKind.Utc).AddTicks(7317));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 3,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 16, 33, 4, 85, DateTimeKind.Utc).AddTicks(7319));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 4,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 18, 4, 85, DateTimeKind.Utc).AddTicks(7327));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 5,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 13, 4, 85, DateTimeKind.Utc).AddTicks(7329));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 6,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 28, 4, 85, DateTimeKind.Utc).AddTicks(7330));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 7,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 23, 4, 85, DateTimeKind.Utc).AddTicks(7332));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 8,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 30, 4, 85, DateTimeKind.Utc).AddTicks(7362));

			migrationBuilder.UpdateData(
				table: "EmergencyAlerts",
				keyColumn: "Id",
				keyValue: 9,
				column: "CreatedAt",
				value: new DateTime(2025, 5, 2, 17, 31, 4, 85, DateTimeKind.Utc).AddTicks(7364));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 1,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7158));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 2,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 17, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7170));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 3,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 22, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7172));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 4,
				column: "LastMaintenance",
				value: new DateTime(2025, 3, 18, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7173));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 5,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 27, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7175));

			migrationBuilder.UpdateData(
				table: "Equipments",
				keyColumn: "Id",
				keyValue: 6,
				column: "LastMaintenance",
				value: new DateTime(2025, 4, 12, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7176));

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 7, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7220), new DateTime(2025, 2, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7213) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 8, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7223), new DateTime(2025, 3, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7222) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 6, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7225), new DateTime(2025, 1, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7225) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 10, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7227), new DateTime(2025, 4, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7227) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 8, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7230), new DateTime(2024, 12, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7229) });

			migrationBuilder.UpdateData(
				table: "Fields",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "HarvestDate", "PlantingDate" },
				values: new object[] { new DateTime(2025, 9, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7233), new DateTime(2024, 11, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7232) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6941), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6941) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6945), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6945) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6948), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6948) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6950), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6951) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6953), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6953) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6955), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6956) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 7,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6958), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6958) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 8,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6960), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6961) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 9,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6963), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6963) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 10,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6965), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6966) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 11,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6968), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6968) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 12,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6970), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6971) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 13,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6973), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6973) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 14,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6975), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(6976) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 15,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7020), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7020) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 16,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7022), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7023) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 17,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7025), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7025) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 18,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7027), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7027) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 19,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7030), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7030) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 20,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7032), new DateTime(2025, 5, 2, 17, 33, 4, 85, DateTimeKind.Utc).AddTicks(7032) });
		}
	}
}
