using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class addimageurlcolumntoapplicationuser : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{

			migrationBuilder.AddColumn<string>(
				name: "ImageUrl",
				table: "AspNetUsers",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ImageUrl",
				table: "AspNetUsers");
		}
	}
}
