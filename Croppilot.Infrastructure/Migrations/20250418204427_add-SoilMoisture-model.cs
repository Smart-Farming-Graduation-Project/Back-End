using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSoilMoisturemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "SoilMoistures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moisture = table.Column<int>(type: "int", nullable: false),
                    Optimal = table.Column<int>(type: "int", nullable: false),
                    PH = table.Column<float>(type: "real", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilMoistures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoilMoistures_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SoilMoistures",
                columns: new[] { "Id", "FieldId", "FieldName", "Moisture", "Optimal", "PH" },
                values: new object[,]
                {
                    { 1, 1, "Field Alpha", 58, 65, 6.2f },
                    { 2, 2, "Field Beta", 62, 60, 6.5f },
                    { 3, 3, "Field Gamma", 70, 68, 6.8f },
                    { 4, 4, "Field Delta", 45, 60, 5.9f },
                    { 5, 5, "Field Epsilon", 67, 70, 6.3f },
                    { 6, 6, "Field Zeta", 52, 60, 6f }
                });


            migrationBuilder.CreateIndex(
                name: "IX_SoilMoistures_FieldId",
                table: "SoilMoistures",
                column: "FieldId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "SoilMoistures");
        }
    }
}
