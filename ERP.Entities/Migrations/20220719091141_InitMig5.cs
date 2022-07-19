using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class InitMig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EMPEmployeeId",
                table: "AdminUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdminRoleId",
                table: "AdminUserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers",
                column: "EMPEmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EMPEmployeeId",
                table: "AdminUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdminRoleId",
                table: "AdminUserRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers",
                column: "EMPEmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id");
        }
    }
}
