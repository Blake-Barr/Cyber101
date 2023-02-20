using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchfulEye.Migrations
{
    public partial class simlevelcontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "levelNum",
                table: "simLevels",
                newName: "LevelNum");

            migrationBuilder.RenameColumn(
                name: "gameType",
                table: "simLevels",
                newName: "GameType");

            migrationBuilder.AddColumn<string>(
                name: "HTMLContent",
                table: "simLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "simContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameType = table.Column<int>(type: "int", nullable: false),
                    HTMLContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_simContent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "simContent");

            migrationBuilder.DropColumn(
                name: "HTMLContent",
                table: "simLevels");

            migrationBuilder.RenameColumn(
                name: "LevelNum",
                table: "simLevels",
                newName: "levelNum");

            migrationBuilder.RenameColumn(
                name: "GameType",
                table: "simLevels",
                newName: "gameType");
        }
    }
}
