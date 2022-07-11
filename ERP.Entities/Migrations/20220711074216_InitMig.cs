using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class InitMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMPEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmpoloyeeNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdentifyNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUsers_EMPEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    AdminUserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_AdminRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_AdminUsers_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_EMPEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_AdminUserId",
                table: "AdminUserRoles",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_EmployeeId",
                table: "AdminUserRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_RoleId",
                table: "AdminUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_EmployeeId",
                table: "AdminUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPEmployees_EmpoloyeeNo",
                table: "EMPEmployees",
                column: "EmpoloyeeNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPEmployees_IdentifyNo",
                table: "EMPEmployees",
                column: "IdentifyNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminForms");

            migrationBuilder.DropTable(
                name: "AdminUserRoles");

            migrationBuilder.DropTable(
                name: "AdminRoles");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "EMPEmployees");
        }
    }
}
