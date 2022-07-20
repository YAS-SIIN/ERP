using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class AddCartableAndInOutTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImaghePath",
                table: "EMPEmployees",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<int>(
                name: "AdminSubSystemId",
                table: "AdminForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminSubSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSubSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CARCartables",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: false),
                    FieldCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmType = table.Column<short>(type: "smallint", nullable: false),
                    SignDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AdminRoleId = table.Column<int>(type: "int", nullable: true),
                    EMPEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARCartables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARCartables_AdminRoles_AdminRoleId",
                        column: x => x.AdminRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CARCartables_EMPEmployees_EMPEmployeeId",
                        column: x => x.EMPEmployeeId,
                        principalTable: "EMPEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CARTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdminFormId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARTable_AdminForms_AdminFormId",
                        column: x => x.AdminFormId,
                        principalTable: "AdminForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InOutRequestLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RequestLeaveType = table.Column<short>(type: "smallint", nullable: false),
                    LeaveType = table.Column<short>(type: "smallint", nullable: false),
                    FromDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ToDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FromTime = table.Column<TimeSpan>(type: "time", maxLength: 10, nullable: true),
                    ToTime = table.Column<TimeSpan>(type: "time", maxLength: 10, nullable: true),
                    LeaveDay = table.Column<int>(type: "int", nullable: false),
                    LeaveTime = table.Column<int>(type: "int", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMPEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOutRequestLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InOutRequestLeaves_EMPEmployees_EMPEmployeeId",
                        column: x => x.EMPEmployeeId,
                        principalTable: "EMPEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CARCartableTrace",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    SignTitle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SignName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CARTableId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARCartableTrace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARCartableTrace_CARTable_CARTableId",
                        column: x => x.CARTableId,
                        principalTable: "CARTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminForms_AdminSubSystemId",
                table: "AdminForms",
                column: "AdminSubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_AdminRoleId",
                table: "CARCartables",
                column: "AdminRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_EMPEmployeeId",
                table: "CARCartables",
                column: "EMPEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartableTrace_CARTableId",
                table: "CARCartableTrace",
                column: "CARTableId");

            migrationBuilder.CreateIndex(
                name: "IX_CARTable_AdminFormId",
                table: "CARTable",
                column: "AdminFormId");

            migrationBuilder.CreateIndex(
                name: "IX_InOutRequestLeaves_EMPEmployeeId",
                table: "InOutRequestLeaves",
                column: "EMPEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminForms_AdminSubSystems_AdminSubSystemId",
                table: "AdminForms",
                column: "AdminSubSystemId",
                principalTable: "AdminSubSystems",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminForms_AdminSubSystems_AdminSubSystemId",
                table: "AdminForms");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                table: "AdminUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                table: "AdminUsers");

            migrationBuilder.DropTable(
                name: "AdminSubSystems");

            migrationBuilder.DropTable(
                name: "CARCartables");

            migrationBuilder.DropTable(
                name: "CARCartableTrace");

            migrationBuilder.DropTable(
                name: "InOutRequestLeaves");

            migrationBuilder.DropTable(
                name: "CARTable");

            migrationBuilder.DropIndex(
                name: "IX_AdminForms_AdminSubSystemId",
                table: "AdminForms");

            migrationBuilder.DropColumn(
                name: "ImaghePath",
                table: "EMPEmployees");

            migrationBuilder.DropColumn(
                name: "AdminSubSystemId",
                table: "AdminForms");

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
    }
}
