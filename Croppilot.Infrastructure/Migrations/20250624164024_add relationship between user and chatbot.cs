using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class addrelationshipbetweenuserandchatbot : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "UserId",
				table: "ChatHistories",
				type: "nvarchar(450)",
				nullable: true);


			migrationBuilder.CreateIndex(
				name: "IX_ChatHistories_UserId",
				table: "ChatHistories",
				column: "UserId");

			migrationBuilder.AddForeignKey(
				name: "FK_ChatHistories_AspNetUsers_UserId",
				table: "ChatHistories",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ChatHistories_AspNetUsers_UserId",
				table: "ChatHistories");

			migrationBuilder.DropIndex(
				name: "IX_ChatHistories_UserId",
				table: "ChatHistories");

			migrationBuilder.DropColumn(
				name: "UserId",
				table: "ChatHistories");

		}
	}
}
