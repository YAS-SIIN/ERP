using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class InitMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminSubSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubSystemNameFarsi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                name: "EMPEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmpoloyeeNo = table.Column<int>(type: "int", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdentifyNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<short>(type: "smallint", nullable: false),
                    HireDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeaveDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ImaghePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormNameFarsi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdminSubSystemId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminForms_AdminSubSystems_AdminSubSystemId",
                        column: x => x.AdminSubSystemId,
                        principalTable: "AdminSubSystems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMPEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUsers_EMPEmployees_EMPEmployeeId",
                        column: x => x.EMPEmployeeId,
                        principalTable: "EMPEmployees",
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
                    TimeLeaveDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FromTime = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ToTime = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LeaveDay = table.Column<int>(type: "int", nullable: false),
                    LeaveTime = table.Column<int>(type: "int", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                name: "ServRequestServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RequestServiceType = table.Column<short>(type: "smallint", nullable: false),
                    ServicesOrGoods = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EMPEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServRequestServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServRequestServices_EMPEmployees_EMPEmployeeId",
                        column: x => x.EMPEmployeeId,
                        principalTable: "EMPEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CARTables",
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
                    table.PrimaryKey("PK_CARTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARTables_AdminForms_AdminFormId",
                        column: x => x.AdminFormId,
                        principalTable: "AdminForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminRoleId = table.Column<int>(type: "int", nullable: true),
                    AdminUserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_AdminRoles_AdminRoleId",
                        column: x => x.AdminRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_AdminUsers_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SessionUser = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminUserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_AdminUsers_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CARCartableTrace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    SignTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SignTitleFa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CARTableId = table.Column<int>(type: "int", nullable: true),
                    AdminRoleId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARCartableTrace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARCartableTrace_AdminRoles_AdminRoleId",
                        column: x => x.AdminRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CARCartableTrace_CARTables_CARTableId",
                        column: x => x.CARTableId,
                        principalTable: "CARTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CARCartables",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: false),
                    FieldCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequestDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ConfirmType = table.Column<short>(type: "smallint", nullable: false),
                    SignDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EMPEmployeeId = table.Column<int>(type: "int", nullable: true),
                    CARCartableTraceId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARCartables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARCartables_CARCartableTrace_CARCartableTraceId",
                        column: x => x.CARCartableTraceId,
                        principalTable: "CARCartableTrace",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CARCartables_EMPEmployees_EMPEmployeeId",
                        column: x => x.EMPEmployeeId,
                        principalTable: "EMPEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminForms_AdminSubSystemId",
                table: "AdminForms",
                column: "AdminSubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRoles_RoleName",
                table: "AdminRoles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_AdminRoleId",
                table: "AdminUserRoles",
                column: "AdminRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_AdminUserId",
                table: "AdminUserRoles",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_EMPEmployeeId",
                table: "AdminUsers",
                column: "EMPEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_CARCartableTraceId",
                table: "CARCartables",
                column: "CARCartableTraceId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_EMPEmployeeId",
                table: "CARCartables",
                column: "EMPEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartableTrace_AdminRoleId",
                table: "CARCartableTrace",
                column: "AdminRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartableTrace_CARTableId",
                table: "CARCartableTrace",
                column: "CARTableId");

            migrationBuilder.CreateIndex(
                name: "IX_CARTables_AdminFormId",
                table: "CARTables",
                column: "AdminFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPEmployees_EmpoloyeeNo",
                table: "EMPEmployees",
                column: "EmpoloyeeNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPEmployees_NationalCode",
                table: "EMPEmployees",
                column: "NationalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InOutRequestLeaves_EMPEmployeeId",
                table: "InOutRequestLeaves",
                column: "EMPEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServRequestServices_EMPEmployeeId",
                table: "ServRequestServices",
                column: "EMPEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AdminUserId",
                table: "Sessions",
                column: "AdminUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUserRoles");

            migrationBuilder.DropTable(
                name: "CARCartables");

            migrationBuilder.DropTable(
                name: "InOutRequestLeaves");

            migrationBuilder.DropTable(
                name: "ServRequestServices");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "CARCartableTrace");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "AdminRoles");

            migrationBuilder.DropTable(
                name: "CARTables");

            migrationBuilder.DropTable(
                name: "EMPEmployees");

            migrationBuilder.DropTable(
                name: "AdminForms");

            migrationBuilder.DropTable(
                name: "AdminSubSystems");
        }
    }
}
