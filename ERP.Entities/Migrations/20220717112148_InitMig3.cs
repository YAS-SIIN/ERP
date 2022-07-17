using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class InitMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_EMPEmployees_EMPEmployeeId",
                table: "AdminUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AdminUserRoles_EMPEmployeeId",
                table: "AdminUserRoles");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "EMPEmployeeId",
                table: "AdminUserRoles");

            migrationBuilder.AddColumn<int>(
                name: "AdminUserId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AdminUserId",
                table: "Sessions",
                column: "AdminUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AdminUsers_AdminUserId",
                table: "Sessions",
                column: "AdminUserId",
                principalTable: "AdminUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AdminUsers_AdminUserId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_AdminUserId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "AdminUserId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EMPEmployeeId",
                table: "AdminUserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_EMPEmployeeId",
                table: "AdminUserRoles",
                column: "EMPEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserRoles_EMPEmployees_EMPEmployeeId",
                table: "AdminUserRoles",
                column: "EMPEmployeeId",
                principalTable: "EMPEmployees",
                principalColumn: "Id");
        }
    }
}
