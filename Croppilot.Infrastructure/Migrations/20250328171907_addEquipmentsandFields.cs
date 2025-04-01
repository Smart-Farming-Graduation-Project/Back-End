using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEquipmentsandFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursUsed = table.Column<double>(type: "float", nullable: false),
                    Battery = table.Column<double>(type: "float", nullable: false),
                    Connectivity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Crop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Irrigation = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Fields");
        }
    }
}
