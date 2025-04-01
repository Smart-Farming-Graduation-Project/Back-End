using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class createcupontableandeditproducttable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "CuponId",
				table: "Products",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "UserId",
				table: "Products",
				type: "nvarchar(450)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.Sql("UPDATE Products SET UserId = '0327f49b-b4dd-4157-b767-1b1f4d50ee00'");

			migrationBuilder.CreateTable(
				name: "Cupons",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Discount_Type = table.Column<int>(type: "int", nullable: false),
					Discount_Value = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
					ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					UsageLimit = table.Column<int>(type: "int", nullable: false),
					UsageCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Cupons", x => x.Id);
					table.CheckConstraint("CK_Cupon_Discount_Value", "Discount_Value > 0");
					table.CheckConstraint("ck_Cupon_ExpirationDate", "ExpirationDate > GetDate()");
					table.CheckConstraint("CK_Cupon_UsageLimit", "UsageLimit > 0");
					table.ForeignKey(
						name: "FK_Cupons_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Products_CuponId",
				table: "Products",
				column: "CuponId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_UserId",
				table: "Products",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Cupons_Code",
				table: "Cupons",
				column: "Code",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Cupons_UserId",
				table: "Cupons",
				column: "UserId");

			migrationBuilder.AddForeignKey(
				name: "FK_Products_AspNetUsers_UserId",
				table: "Products",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Products_Cupons_CuponId",
				table: "Products",
				column: "CuponId",
				principalTable: "Cupons",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Products_AspNetUsers_UserId",
				table: "Products");

			migrationBuilder.DropForeignKey(
				name: "FK_Products_Cupons_CuponId",
				table: "Products");

			migrationBuilder.DropTable(
				name: "Cupons");

			migrationBuilder.DropIndex(
				name: "IX_Products_CuponId",
				table: "Products");

			migrationBuilder.DropIndex(
				name: "IX_Products_UserId",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "CuponId",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Products");
		}
	}
}
