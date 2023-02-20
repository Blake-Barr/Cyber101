using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchfulEye.Migrations
{
    public partial class simlevel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SimulatorLevel_AssignedLevelId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimulatorLevel",
                table: "SimulatorLevel");

            migrationBuilder.RenameTable(
                name: "SimulatorLevel",
                newName: "simLevels");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_simLevels",
                table: "simLevels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_simLevels_AssignedLevelId",
                table: "AspNetUsers",
                column: "AssignedLevelId",
                principalTable: "simLevels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_simLevels_AssignedLevelId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_simLevels",
                table: "simLevels");

            migrationBuilder.RenameTable(
                name: "simLevels",
                newName: "SimulatorLevel");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimulatorLevel",
                table: "SimulatorLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SimulatorLevel_AssignedLevelId",
                table: "AspNetUsers",
                column: "AssignedLevelId",
                principalTable: "SimulatorLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
