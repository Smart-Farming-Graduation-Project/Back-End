using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editcuponDiscountTypeMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discount_Type",
                table: "Cupons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount_Type",
                table: "Cupons",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
