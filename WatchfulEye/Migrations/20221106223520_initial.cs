using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchfulEye.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    difficultyLevel = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    header = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FakeSite",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fakeURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeSite", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "FakeSite");
        }
    }
}
