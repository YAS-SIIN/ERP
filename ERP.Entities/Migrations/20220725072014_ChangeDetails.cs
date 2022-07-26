using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class ChangeDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EMPEmployees_IdentifyNo",
                table: "EMPEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_EMPEmployees_NationalCode",
                table: "EMPEmployees",
                column: "NationalCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EMPEmployees_NationalCode",
                table: "EMPEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_EMPEmployees_IdentifyNo",
                table: "EMPEmployees",
                column: "IdentifyNo",
                unique: true);
        }
    }
}
