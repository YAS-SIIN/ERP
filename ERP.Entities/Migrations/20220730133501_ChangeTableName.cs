using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartables_CARCartableTrace_CARCartableTraceId",
                table: "CARCartables");

            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTrace_AdminRoles_AdminRoleId",
                table: "CARCartableTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTrace_CARTables_CARTableId",
                table: "CARCartableTrace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARCartableTrace",
                table: "CARCartableTrace");

            migrationBuilder.RenameTable(
                name: "CARCartableTrace",
                newName: "CARCartableTraces");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTrace_CARTableId",
                table: "CARCartableTraces",
                newName: "IX_CARCartableTraces_CARTableId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTrace_AdminRoleId",
                table: "CARCartableTraces",
                newName: "IX_CARCartableTraces_AdminRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARCartableTraces",
                table: "CARCartableTraces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartables_CARCartableTraces_CARCartableTraceId",
                table: "CARCartables",
                column: "CARCartableTraceId",
                principalTable: "CARCartableTraces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartableTraces_AdminRoles_AdminRoleId",
                table: "CARCartableTraces",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartableTraces_CARTables_CARTableId",
                table: "CARCartableTraces",
                column: "CARTableId",
                principalTable: "CARTables",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartables_CARCartableTraces_CARCartableTraceId",
                table: "CARCartables");

            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTraces_AdminRoles_AdminRoleId",
                table: "CARCartableTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_CARCartableTraces_CARTables_CARTableId",
                table: "CARCartableTraces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARCartableTraces",
                table: "CARCartableTraces");

            migrationBuilder.RenameTable(
                name: "CARCartableTraces",
                newName: "CARCartableTrace");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTraces_CARTableId",
                table: "CARCartableTrace",
                newName: "IX_CARCartableTrace_CARTableId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTraces_AdminRoleId",
                table: "CARCartableTrace",
                newName: "IX_CARCartableTrace_AdminRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARCartableTrace",
                table: "CARCartableTrace",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartables_CARCartableTrace_CARCartableTraceId",
                table: "CARCartables",
                column: "CARCartableTraceId",
                principalTable: "CARCartableTrace",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartableTrace_AdminRoles_AdminRoleId",
                table: "CARCartableTrace",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartableTrace_CARTables_CARTableId",
                table: "CARCartableTrace",
                column: "CARTableId",
                principalTable: "CARTables",
                principalColumn: "Id");
        }
    }
}
