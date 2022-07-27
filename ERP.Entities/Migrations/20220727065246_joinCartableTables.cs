using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class joinCartableTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteFlag",
                table: "CARCartables");

            migrationBuilder.AddColumn<double>(
                name: "CARCartableTraceId",
                table: "CARCartables",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARCartables_CARCartableTraceId",
                table: "CARCartables",
                column: "CARCartableTraceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CARCartables_CARCartableTrace_CARCartableTraceId",
                table: "CARCartables",
                column: "CARCartableTraceId",
                principalTable: "CARCartableTrace",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARCartables_CARCartableTrace_CARCartableTraceId",
                table: "CARCartables");

            migrationBuilder.DropIndex(
                name: "IX_CARCartables_CARCartableTraceId",
                table: "CARCartables");

            migrationBuilder.DropColumn(
                name: "CARCartableTraceId",
                table: "CARCartables");

            migrationBuilder.AddColumn<bool>(
                name: "DeleteFlag",
                table: "CARCartables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
