using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.DataAccess.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Coordinators_CoordinatorId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinatorId",
                table: "Workers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Coordinators_CoordinatorId",
                table: "Workers",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Coordinators_CoordinatorId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinatorId",
                table: "Workers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Coordinators_CoordinatorId",
                table: "Workers",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
