using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addchatHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "LastName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "FirstName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "OTPExpiration",
            //    table: "AspNetUsers",
            //    type: "datetime2",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BotResponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatHistories", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //name: "Reviews",
            //columns: table => new
            //{
            //    ReviewID = table.Column<int>(type: "int", nullable: false)
            //        .Annotation("SqlServer:Identity", "1, 1"),
            //    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //    ProductID = table.Column<int>(type: "int", nullable: false),
            //    Headline = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //    Rating = table.Column<int>(type: "int", nullable: false),
            //    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
            //    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            //},
            //constraints: table =>
            //{
            //    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
            //    table.CheckConstraint("CK_Review_Rating", "[Rating] BETWEEN 1 AND 5");
            //    table.ForeignKey(
            //        name: "FK_Reviews_AspNetUsers_UserID",
            //        column: x => x.UserID,
            //        principalTable: "AspNetUsers",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Cascade);
            //    table.ForeignKey(
            //        name: "FK_Reviews_Products_ProductID",
            //        column: x => x.ProductID,
            //        principalTable: "Products",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Cascade);
            //});

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Reviews_ProductID",
            //        table: "Reviews",
            //        column: "ProductID");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Reviews_UserID",
            //        table: "Reviews",
            //        column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatHistories");

            //migrationBuilder.DropTable(
            //    name: "Reviews");

            //migrationBuilder.DropColumn(
            //    name: "OTPExpiration",
            //    table: "AspNetUsers");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LastName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "FirstName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");
        }
    }
}
