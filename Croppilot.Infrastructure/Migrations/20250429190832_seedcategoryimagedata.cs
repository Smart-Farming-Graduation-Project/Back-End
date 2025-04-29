using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class seedcategoryimagedata : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 1,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/0bdbd4c8-2503-427c-b4fe-ffa6e5c57a23_Fresh Vegetables.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 2,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/5caaf20a-3510-4d38-b2b4-b16e79cf45ab_Seasonal Fruits.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 3,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/61cd1282-c3c4-4ef3-9b2c-ae7d5beb482c_Dairy Products.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 4,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/b7f5884a-6833-43f0-bb78-367c371a37fb_Organic Eggs.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 5,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/9aa3dfb7-12b7-4631-908c-eb11fa0c64f9_Ornamental Plants.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 6,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/28773f2f-5619-406e-8c74-1cd82b296d3f_Seedlings.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 7,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/a5a834c1-736c-4858-95df-673e21014525_Organic Animal Feed.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 8,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/c10224a6-0625-41a3-8332-73433f96f39e_Farming Tools.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 9,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/6c4bef01-1181-4fde-8bc4-78331a8c82d2_Premium Seeds.jpg");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 10,
				column: "ImageUrl",
				value: "https://graduationprojetct.blob.core.windows.net/category-images/242d456f-5b41-4d3a-8744-cd18ec583aae_Organic Fertilizers.jpg");

		}
		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 1,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 2,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 3,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 4,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 5,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 6,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 7,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 8,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 9,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 10,
				column: "ImageUrl",
				value: "");

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9832), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9832) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9836), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9836) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9839), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9839) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9841), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9842) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9844), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9844) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9847), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9847) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 7,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9849), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9850) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 8,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9852), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9852) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 9,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9854), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9854) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 10,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9857), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9857) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 11,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9859), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9859) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 12,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9862), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9862) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 13,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9864), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9864) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 14,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9867), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9867) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 15,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9869), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9869) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 16,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9872), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9872) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 17,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9874), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9874) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 18,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9877), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9877) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 19,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9879), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9879) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 20,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9882), new DateTime(2025, 4, 29, 18, 24, 0, 625, DateTimeKind.Utc).AddTicks(9882) });
		}
	}
}
