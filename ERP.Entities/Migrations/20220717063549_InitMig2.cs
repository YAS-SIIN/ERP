using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class InitMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Gender",
                table: "EMPEmployees",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "HireDate",
                table: "EMPEmployees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeaveDate",
                table: "EMPEmployees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "EMPEmployees",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "EMPEmployees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AdminUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AdminUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "AdminUsers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "AdminUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "AdminUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "AdminUserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "AdminRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "AdminForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EMPEmployees");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "EMPEmployees");

            migrationBuilder.DropColumn(
                name: "LeaveDate",
                table: "EMPEmployees");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "EMPEmployees");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "EMPEmployees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "AdminUserRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "AdminRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "AdminForms");
        }
    }
}
