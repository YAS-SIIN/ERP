using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class ChangeTableNames : Migration
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
                name: "FK_CARCartableTrace_CARTable_CARTableId",
                table: "CARCartableTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_CARTable_AdminForms_AdminFormId",
                table: "CARTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARTable",
                table: "CARTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARCartableTrace",
                table: "CARCartableTrace");

            migrationBuilder.RenameTable(
                name: "CARTable",
                newName: "CARTables");

            migrationBuilder.RenameTable(
                name: "CARCartableTrace",
                newName: "CARCartableTraces");

            migrationBuilder.RenameIndex(
                name: "IX_CARTable_AdminFormId",
                table: "CARTables",
                newName: "IX_CARTables_AdminFormId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTrace_CARTableId",
                table: "CARCartableTraces",
                newName: "IX_CARCartableTraces_CARTableId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTrace_AdminRoleId",
                table: "CARCartableTraces",
                newName: "IX_CARCartableTraces_AdminRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARTables",
                table: "CARTables",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CARTables_AdminForms_AdminFormId",
                table: "CARTables",
                column: "AdminFormId",
                principalTable: "AdminForms",
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

            migrationBuilder.DropForeignKey(
                name: "FK_CARTables_AdminForms_AdminFormId",
                table: "CARTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARTables",
                table: "CARTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARCartableTraces",
                table: "CARCartableTraces");

            migrationBuilder.RenameTable(
                name: "CARTables",
                newName: "CARTable");

            migrationBuilder.RenameTable(
                name: "CARCartableTraces",
                newName: "CARCartableTrace");

            migrationBuilder.RenameIndex(
                name: "IX_CARTables_AdminFormId",
                table: "CARTable",
                newName: "IX_CARTable_AdminFormId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTraces_CARTableId",
                table: "CARCartableTrace",
                newName: "IX_CARCartableTrace_CARTableId");

            migrationBuilder.RenameIndex(
                name: "IX_CARCartableTraces_AdminRoleId",
                table: "CARCartableTrace",
                newName: "IX_CARCartableTrace_AdminRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARTable",
                table: "CARTable",
                column: "Id");

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
                name: "FK_CARCartableTrace_CARTable_CARTableId",
                table: "CARCartableTrace",
                column: "CARTableId",
                principalTable: "CARTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CARTable_AdminForms_AdminFormId",
                table: "CARTable",
                column: "AdminFormId",
                principalTable: "AdminForms",
                principalColumn: "Id");
        }
    }
}
