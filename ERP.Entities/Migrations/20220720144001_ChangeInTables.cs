using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class ChangeInTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AdminUsers_AdminUserId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "AdminUserId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ToTime",
                table: "InOutRequestLeaves",
                type: "time",
                maxLength: 10,
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LeaveReason",
                table: "InOutRequestLeaves",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FromTime",
                table: "InOutRequestLeaves",
                type: "time",
                maxLength: 10,
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpoloyeeNo",
                table: "EMPEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "AdminUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AdminUsers_AdminUserId",
                table: "Sessions",
                column: "AdminUserId",
                principalTable: "AdminUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AdminUsers_AdminUserId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "AdminUserId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ToTime",
                table: "InOutRequestLeaves",
                type: "time",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LeaveReason",
                table: "InOutRequestLeaves",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FromTime",
                table: "InOutRequestLeaves",
                type: "time",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "EmpoloyeeNo",
                table: "EMPEmployees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "AdminUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AdminUsers_AdminUserId",
                table: "Sessions",
                column: "AdminUserId",
                principalTable: "AdminUsers",
                principalColumn: "Id");
        }
    }
}
