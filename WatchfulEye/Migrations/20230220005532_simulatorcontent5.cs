using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchfulEye.Migrations
{
    public partial class simulatorcontent5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LevelDesc",
                table: "simLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelName",
                table: "simLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelDesc",
                table: "simLevels");

            migrationBuilder.DropColumn(
                name: "LevelName",
                table: "simLevels");
        }
    }
}
