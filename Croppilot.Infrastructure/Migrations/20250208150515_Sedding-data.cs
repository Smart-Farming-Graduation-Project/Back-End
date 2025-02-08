using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seddingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "High-quality seeds for farming", "Seeds" },
                    { 2, "Organic and chemical fertilizers", "Fertilizers" },
                    { 3, "Tractors, plows, and other farming tools", "Farming Equipment" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2025, 2, 8, 15, 5, 14, 746, DateTimeKind.Utc).AddTicks(7172), "High-yield wheat seeds suitable for all climates", "Wheat Seeds", 19.99m, new DateTime(2025, 2, 8, 15, 5, 14, 746, DateTimeKind.Utc).AddTicks(7172) },
                    { 2, 0, 2, new DateTime(2025, 2, 8, 15, 5, 14, 746, DateTimeKind.Utc).AddTicks(7176), "Natural compost-based fertilizer for better crop growth", "Organic Fertilizer", 49.99m, new DateTime(2025, 2, 8, 15, 5, 14, 746, DateTimeKind.Utc).AddTicks(7176) },
                    { 3, 1, 3, new DateTime(2025, 2, 8, 15, 5, 14, 746, DateTimeKind.Utc).AddTicks(7179), "Compact tractor for small to medium-sized farms", "Mini Tractor", 4999.99m, new DateTime(2025, 2, 8, 15, 5, 14, 746, DateTimeKind.Utc).AddTicks(7179) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://example.com/wheat-seeds.jpg", 1 },
                    { 2, "https://example.com/organic-fertilizer.jpg", 2 },
                    { 3, "https://example.com/mini-tractor.jpg", 3 }
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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
