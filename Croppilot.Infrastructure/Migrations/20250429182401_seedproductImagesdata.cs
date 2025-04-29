using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class seedproductImagesdata : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "ProductImages",
				columns: new[] { "Id", "ImageUrl", "ProductId" },
				values: new object[,]
				{
					{ 1, "https://graduationprojetct.blob.core.windows.net/product-images/Organic Tomatoes_2520f86d-8700-4b06-bed5-e9e317e71d95_R %283%29.jpg", 1 },
					{ 2, "https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_d29f0202-cbf9-4f0e-ae62-344521eec15c_R %284%29.jpg", 2 },
					{ 3, "https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_771c182f-18c0-43b4-af95-281406ed89fe_OIP.jpg", 2 },
					{ 4, "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_765ca4be-6179-4ce9-bed6-57613481d475_OIP %281%29.jpg", 3 },
					{ 5, "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_7d5babea-020f-4e79-8552-9450f997853e_primary-430.jpg", 3 },
					{ 6, "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_d561a4c3-5e47-4ec4-9a40-dccc6b7157bc_Bell-Peppers.jpg", 3 },
					{ 7, "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_b66be9e1-5421-4592-9038-a546c2c49bd6_R %285%29.jpg", 7 },
					{ 8, "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_affe0646-14b5-4440-9373-823c0aab4132_R %286%29.jpg", 7 },
					{ 9, "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_5d1f9c4f-444c-49d3-8cb0-eb4e1ff19d40_R %287%29.jpg", 7 },
					{ 10, "https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_eefc35b5-e857-4cf5-a5a3-b09fa75f3c6f_R %288%29.jpg", 4 },
					{ 11, "https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_779eca40-dfb3-4c51-9ae4-f6d022bdea1a_R %289%29.jpg", 4 },
					{ 12, "https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_d0c89732-4204-4804-ba7c-d0ef0a822573_download.jpg", 5 },
					{ 13, "https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_0aa7f942-c40f-4f0f-a2d0-f960d599a9d2_OIP %282%29.jpg", 5 },
					{ 14, "https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_f13f305a-8f7d-4bdd-ad67-08982d51bd88_OIP %283%29.jpg", 6 },
					{ 15, "https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_5a90c66a-c7c8-4de4-8ae3-c5d763f63955_OIP %284%29.jpg", 6 },
					{ 16, "https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_a1d3e7ec-afba-4883-812d-30216c3cb4e7_R %2810%29.jpg", 8 },
					{ 17, "https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_26e0102e-b43e-4124-b3af-9d87e6ad5ce5_OIP %285%29.jpg", 8 },
					{ 18, "https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_c5f98e11-0931-43e2-9d9a-fd70f42a5dbd_OIP %286%29.jpg", 9 },
					{ 19, "https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_7337ee02-8893-4ab2-aec7-cb1414df80dd_R %2811%29.jpg", 9 },
					{ 20, "https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_2d35c5fc-6d4c-4f8e-aa13-1c16ed674601_OIP %287%29.jpg", 10 },
					{ 21, "https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_33b205d9-91da-40ef-9a96-c9a0337b3fe4_OIP %288%29.jpg", 10 },
					{ 22, "https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_c7bff713-4c6c-4352-869e-c85f673baf1f_R %2812%29.jpg", 11 },
					{ 23, "https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_edb3d662-5727-4c71-93a5-bb460cddd3c3_OIP %289%29.jpg", 11 },
					{ 24, "https://graduationprojetct.blob.core.windows.net/product-images/Lavender Plant_53ef2c19-0a3b-4114-b178-32c1a6110069_OIP %2810%29.jpg", 12 },
					{ 25, "https://graduationprojetct.blob.core.windows.net/product-images/Tomato Seedlings_e6e9622b-bbc1-4aa6-96b2-297ebb8257f4_IMG_9275.jpg", 13 },
					{ 26, "https://graduationprojetct.blob.core.windows.net/product-images/Cucumber Seedlings_89f422cb-7093-4814-bd2f-0d4ad099cc6e_R %2813%29.jpg", 14 },
					{ 27, "https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_e9e91afb-1a50-4726-bd37-e162ec9ed15a_OIP %2811%29.jpg", 15 },
					{ 28, "https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_2a70c24b-9b7a-4905-af6e-796ab5566709_OIP %2812%29.jpg", 15 },
					{ 29, "https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_c8ec9374-4839-4004-96c1-0054ad698925_OIP %2813%29.jpg", 16 },
					{ 30, "https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_b441f3a3-b774-4efb-bf75-543fa2700a4e_OIP %2814%29.jpg", 16 },
					{ 31, "https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_e40f5237-442d-4452-8f32-2883bcfbe8bf_OIP %2815%29.jpg", 17 },
					{ 32, "https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_54af077d-62db-4fe4-9bcb-ad0fbf184d15_OIP %2816%29.jpg", 17 },
					{ 33, "https://graduationprojetct.blob.core.windows.net/product-images/Garden Hoe_477a31d4-f9c0-4ec2-bd8f-bc81c5aaeaac_OIP %2817%29.jpg", 18 },
					{ 34, "https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_d8e29f75-83a8-4968-992f-343303f0404b_61gvcvZgosL._AC_SL1500_.jpg", 19 },
					{ 35, "https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_a02227ba-a1a8-4053-9f95-7c354402c179_R %2814%29.jpg", 19 },
					{ 36, "https://graduationprojetct.blob.core.windows.net/product-images/Worm Castings_e1155a6c-3ce2-4d69-979f-a8840c282f02_OIP %2818%29.jpg", 20 }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 5);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 6);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 7);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 8);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 9);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 10);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 11);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 12);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 13);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 14);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 15);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 16);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 17);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 18);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 19);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 20);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 21);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 22);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 23);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 24);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 25);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 26);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 27);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 28);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 29);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 30);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 31);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 32);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 33);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 34);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 35);

			migrationBuilder.DeleteData(
				table: "ProductImages",
				keyColumn: "Id",
				keyValue: 36);

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1787), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1788) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1791), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1791) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1794), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1794) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1796), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1797) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1799), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1799) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1801), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1801) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 7,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1804), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1804) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 8,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1806), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1806) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 9,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1808), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1809) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 10,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1811), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1811) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 11,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1813), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1814) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 12,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1816), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1816) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 13,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1818), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1819) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 14,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1821), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1821) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 15,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1823), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1823) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 16,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1825), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1826) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 17,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1828), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1828) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 18,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1830), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1830) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 19,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1832), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1833) });

			migrationBuilder.UpdateData(
				table: "Products",
				keyColumn: "Id",
				keyValue: 20,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1835), new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1835) });
		}
	}
}
