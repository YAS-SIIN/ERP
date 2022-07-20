using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class ChangeInInOutRequestLeaveTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ToTime",
                table: "InOutRequestLeaves",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FromTime",
                table: "InOutRequestLeaves",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ToTime",
                table: "InOutRequestLeaves",
                type: "time",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FromTime",
                table: "InOutRequestLeaves",
                type: "time",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);
        }
    }
}
