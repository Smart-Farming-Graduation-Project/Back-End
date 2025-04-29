using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedproductsdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "CreatedAt", "CuponId", "Description", "Name", "Price", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1787), null, "Fresh vine-ripened tomatoes", "Organic Tomatoes", 19.99m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1788), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 2, 0, 1, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1791), null, "Crisp and refreshing cucumbers", "Cucumbers", 12.50m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1791), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 3, 1, 1, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1794), null, "Mixed color sweet peppers", "Bell Peppers", 18.75m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1794), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 4, 0, 2, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1796), null, "Sweet and juicy strawberries", "Strawberries", 25.99m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1797), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 5, 0, 2, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1799), null, "Premium imported mangoes", "Mangoes", 30.50m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1799), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 6, 0, 2, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1801), null, "Large sweet watermelons", "Watermelons", 45.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1801), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 7, 0, 3, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1804), null, "Whole milk 1L bottle", "Farm Fresh Milk", 20.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1804), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 8, 0, 3, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1806), null, "Aged cheddar cheese 200g", "Artisan Cheese", 35.75m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1806), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 9, 0, 3, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1808), null, "Natural Yogurt", "Natural Yogurt", 18.50m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1809), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 10, 0, 4, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1811), null, "Large brown eggs", "Free-Range Eggs (12pk)", 30.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1811), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 11, 0, 5, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1813), null, "Red rose plant in 12\" pot", "Rose Bush", 120.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1814), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 12, 0, 5, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1816), null, "Fragrant lavender for gardens", "Lavender Plant", 85.50m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1816), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 13, 0, 6, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1818), null, "Early girl tomato plants", "Tomato Seedlings", 15.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1819), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 14, 0, 6, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1821), null, "Burpless cucumber plants, disease-resistant", "Cucumber Seedlings", 13.25m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1821), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 15, 0, 7, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1823), null, "Organic chicken feed", "Poultry Feed 20kg", 150.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1823), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 16, 0, 7, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1825), null, "Nutritional cattle mix", "Cattle Feed 25kg", 220.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1826), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 17, 0, 8, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1828), null, "Professional grade shears", "Pruning Shears", 65.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1828), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 18, 0, 8, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1830), null, "Sturdy steel garden hoe", "Garden Hoe", 45.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1830), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 19, 0, 10, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1832), null, "Nutrient-rich compost", "Compost 10kg", 40.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1833), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" },
                    { 20, 0, 10, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1835), null, "Organic soil amendment", "Worm Castings", 55.00m, new DateTime(2025, 4, 29, 14, 44, 22, 181, DateTimeKind.Utc).AddTicks(1835), "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
