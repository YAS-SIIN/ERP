using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class FixRelations2AndAddAdminFormRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartables_AdminForms_AdminFormId",
                table: "CARCartables");

            migrationBuilder.DropForeignKey(
                name: "FK_CARCartables_AdminRoles_AdminRoleId",
                table: "CARCartables");

            migrationBuilder.DropIndex(
                name: "IX_CARCartables_AdminFormId",
                table: "CARCartables");

            migrationBuilder.DropIndex(
                name: "IX_CARCartables_AdminRoleId",
                table: "CARCartables");

            migrationBuilder.DropColumn(
                name: "AdminFormId",
                table: "CARCartables");

            migrationBuilder.DropColumn(
                name: "AdminRoleId",
                table: "CARCartables");

            migrationBuilder.AddColumn<int>(
                name: "AdminFormRoleId",
                table: "CARCartableTrace",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminFormRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminRoleId = table.Column<int>(type: "int", nullable: true),
                    AdminFormId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminFormRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminFormRole_AdminForms_AdminFormId",
                        column: x => x.AdminFormId,
                        principalTable: "AdminForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminFormRole_AdminRoles_AdminRoleId",
                        column: x => x.AdminRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARCartableTrace_AdminFormRoleId",
                table: "CARCartableTrace",
                column: "AdminFormRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminFormRole_AdminFormId",
                table: "AdminFormRole",
                column: "AdminFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminFormRole_AdminRoleId",
                table: "AdminFormRole",
                column: "AdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartableTrace_AdminFormRole_AdminFormRoleId",
                table: "CARCartableTrace",
                column: "AdminFormRoleId",
                principalTable: "AdminFormRole",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTrace_AdminFormRole_AdminFormRoleId",
                table: "CARCartableTrace");

            migrationBuilder.DropTable(
                name: "AdminFormRole");

            migrationBuilder.DropIndex(
                name: "IX_CARCartableTrace_AdminFormRoleId",
                table: "CARCartableTrace");

            migrationBuilder.DropColumn(
                name: "AdminFormRoleId",
                table: "CARCartableTrace");

            migrationBuilder.AddColumn<int>(
                name: "AdminFormId",
                table: "CARCartables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminRoleId",
                table: "CARCartables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_AdminFormId",
                table: "CARCartables",
                column: "AdminFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_AdminRoleId",
                table: "CARCartables",
                column: "AdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartables_AdminForms_AdminFormId",
                table: "CARCartables",
                column: "AdminFormId",
                principalTable: "AdminForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartables_AdminRoles_AdminRoleId",
                table: "CARCartables",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");
        }
    }
}
