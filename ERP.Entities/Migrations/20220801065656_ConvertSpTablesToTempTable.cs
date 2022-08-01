using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class ConvertSpTablesToTempTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARCartableLists");

            migrationBuilder.DropTable(
                name: "SPIntResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARCartableLists",
                columns: table => new
                {
                    CARTableId = table.Column<int>(type: "int", nullable: false),
                    FieldCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormNameFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPIntResults",
                columns: table => new
                {
                    SpReturnResult = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
