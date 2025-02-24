using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addOTPExpiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OTPExpiration",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTPExpiration",
                table: "AspNetUsers");
        }
    }
}
