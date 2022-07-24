using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class FixRelations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTrace_AdminFormRole_AdminFormRoleId",
                table: "CARCartableTrace");

            migrationBuilder.DropTable(
                name: "AdminFormRole");

            migrationBuilder.RenameColumn(
                name: "AdminFormRoleId",
                table: "CARCartableTrace",
                newName: "AdminRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTrace_AdminFormRoleId",
                table: "CARCartableTrace",
                newName: "IX_CARCartableTrace_AdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartableTrace_AdminRoles_AdminRoleId",
                table: "CARCartableTrace",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTrace_AdminRoles_AdminRoleId",
                table: "CARCartableTrace");

            migrationBuilder.RenameColumn(
                name: "AdminRoleId",
                table: "CARCartableTrace",
                newName: "AdminFormRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTrace_AdminRoleId",
                table: "CARCartableTrace",
                newName: "IX_CARCartableTrace_AdminFormRoleId");

            migrationBuilder.CreateTable(
                name: "AdminFormRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminFormId = table.Column<int>(type: "int", nullable: true),
                    AdminRoleId = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
    }
}
