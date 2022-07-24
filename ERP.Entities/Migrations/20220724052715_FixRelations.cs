using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class FixRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminFormId",
                table: "CARCartables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_AdminFormId",
                table: "CARCartables",
                column: "AdminFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartables_AdminForms_AdminFormId",
                table: "CARCartables",
                column: "AdminFormId",
                principalTable: "AdminForms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartables_AdminForms_AdminFormId",
                table: "CARCartables");

            migrationBuilder.DropIndex(
                name: "IX_CARCartables_AdminFormId",
                table: "CARCartables");

            migrationBuilder.DropColumn(
                name: "AdminFormId",
                table: "CARCartables");
        }
    }
}
