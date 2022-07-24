using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class RemoveIsValidFielInSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Sessions");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRoles_RoleName",
                table: "AdminRoles",
                column: "RoleName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdminRoles_RoleName",
                table: "AdminRoles");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
