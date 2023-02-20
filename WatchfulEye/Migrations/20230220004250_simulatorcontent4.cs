using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchfulEye.Migrations
{
    public partial class simulatorcontent4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LevelDescription",
                table: "simContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelTitle",
                table: "simContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelDescription",
                table: "simContent");

            migrationBuilder.DropColumn(
                name: "LevelTitle",
                table: "simContent");
        }
    }
}
