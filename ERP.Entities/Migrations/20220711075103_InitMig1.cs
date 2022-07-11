using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class InitMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_RoleId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_EMPEmployees_EmployeeId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EmployeeId",
                table: "AdminUsers");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "AdminUsers",
                newName: "EMPEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUsers_EmployeeId",
                table: "AdminUsers",
                newName: "IX_AdminUsers_EMPEmployeeId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AdminUserRoles",
                newName: "EMPEmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "AdminUserRoles",
                newName: "AdminRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUserRoles_RoleId",
                table: "AdminUserRoles",
                newName: "IX_AdminUserRoles_EMPEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUserRoles_EmployeeId",
                table: "AdminUserRoles",
                newName: "IX_AdminUserRoles_AdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_EMPEmployees_EMPEmployeeId",
                table: "AdminUserRoles",
                column: "EMPEmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers",
                column: "EMPEmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_EMPEmployees_EMPEmployeeId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers");

            migrationBuilder.RenameColumn(
                name: "EMPEmployeeId",
                table: "AdminUsers",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUsers_EMPEmployeeId",
                table: "AdminUsers",
                newName: "IX_AdminUsers_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EMPEmployeeId",
                table: "AdminUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "AdminRoleId",
                table: "AdminUserRoles",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUserRoles_EMPEmployeeId",
                table: "AdminUserRoles",
                newName: "IX_AdminUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUserRoles_AdminRoleId",
                table: "AdminUserRoles",
                newName: "IX_AdminUserRoles_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_RoleId",
                table: "AdminUserRoles",
                column: "RoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_EMPEmployees_EmployeeId",
                table: "AdminUserRoles",
                column: "EmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EmployeeId",
                table: "AdminUsers",
                column: "EmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id");
        }
    }
}
