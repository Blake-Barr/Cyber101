using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchfulEye.Migrations
{
    public partial class simlevel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SimulatorLevel_AssignedLevelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SimulatorLevel_AssignedLevelId",
                table: "AspNetUsers",
                column: "AssignedLevelId",
                principalTable: "SimulatorLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SimulatorLevel_AssignedLevelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SimulatorLevel_AssignedLevelId",
                table: "AspNetUsers",
                column: "AssignedLevelId",
                principalTable: "SimulatorLevel",
                principalColumn: "Id");
        }
    }
}
