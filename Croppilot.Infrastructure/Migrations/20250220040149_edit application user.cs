using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editapplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 20, "High-quality seeds for farming", "Seeds" },
                    { 21, "Organic and chemical fertilizers", "Fertilizers" },
                    { 22, "Tractors, plows, and other farming tools", "Farming Equipment" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 20, 0, 20, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2331), "High-yield wheat seeds suitable for all climates", "Wheat Seeds", 19.99m, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2332) },
                    { 21, 0, 21, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2334), "Natural compost-based fertilizer for better crop growth", "Organic Fertilizer", 49.99m, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2335) },
                    { 22, 1, 22, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2368), "Compact tractor for small to medium-sized farms", "Mini Tractor", 4999.99m, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2369) },
                    { 23, 0, 20, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2371), "High-quality tomato seeds for high-yield crops", "Tomato Seeds", 15.99m, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2372) },
                    { 24, 0, 21, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2374), "Boosts plant growth with essential nutrients", "Chemical Fertilizer", 39.99m, new DateTime(2025, 2, 14, 20, 23, 18, 11, DateTimeKind.Utc).AddTicks(2374) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 20, "https://example.com/wheat-seeds.jpg", 20 },
                    { 21, "https://example.com/organic-fertilizer.jpg", 21 },
                    { 22, "https://example.com/mini-tractor.jpg", 22 },
                    { 23, "https://example.com/tomato-seeds.jpg", 23 },
                    { 24, "https://example.com/chemical-fertilizer.jpg", 24 }
                });
        }
    }
}
