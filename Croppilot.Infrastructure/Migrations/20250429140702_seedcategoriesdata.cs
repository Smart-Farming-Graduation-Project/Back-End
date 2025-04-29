using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedcategoriesdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Daily harvested organic vegetables", "", "Fresh Vegetables" },
                    { 2, "Naturally grown fruits with authentic flavors", "", "Seasonal Fruits" },
                    { 3, "Fresh cheese and milk from our farm", "", "Dairy Products" },
                    { 4, "Free-range chicken eggs", "", "Organic Eggs" },
                    { 5, "Home garden flowers and decorative plants", "", "Ornamental Plants" },
                    { 6, "Vegetable and fruit starters for home gardening", "", "Seedlings" },
                    { 7, "Natural feed for livestock and poultry", "", "Organic Animal Feed" },
                    { 8, "Essential agricultural equipment", "", "Farming Tools" },
                    { 9, "Certified high-yield seeds", "", "Premium Seeds" },
                    { 10, "Natural soil enhancers", "", "Organic Fertilizers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
