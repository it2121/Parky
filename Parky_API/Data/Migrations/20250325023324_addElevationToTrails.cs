using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parky_API.Migrations
{
    /// <inheritdoc />
    public partial class addElevationToTrails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Elevation",
                table: "Trails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elevation",
                table: "Trails");
        }
    }
}
