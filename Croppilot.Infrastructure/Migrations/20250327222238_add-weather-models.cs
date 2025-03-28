using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addweathermodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    WindSpeed = table.Column<double>(type: "float", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UvIndex = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    High = table.Column<double>(type: "float", nullable: false),
                    Low = table.Column<double>(type: "float", nullable: false),
                    Precipitation = table.Column<double>(type: "float", nullable: false),
                    Wind = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDatas");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
