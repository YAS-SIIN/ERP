using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class AddRequestServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ServRequestServices_EMPEmployeeId",
                table: "ServRequestServices",
                column: "EMPEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServRequestServices");
        }
    }
}
