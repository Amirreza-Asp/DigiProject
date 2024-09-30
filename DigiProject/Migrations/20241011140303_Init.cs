using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Generationtime_ms = table.Column<double>(type: "float", nullable: false),
                    Utc_offset_seconds = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timezone_abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elevation = table.Column<double>(type: "float", nullable: false),
                    Hourly_units_Time = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Hourly_units_Temperature_2m = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Hourly_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hourly_Temperature_2m = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecast");
        }
    }
}
