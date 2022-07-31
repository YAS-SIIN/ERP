using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Entities.Migrations
{
    public partial class AddCARCartableListViewModelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormNameFarsi",
                table: "AdminForms",
                newName: "FormNameFa");

            migrationBuilder.CreateTable(
                name: "CARCartableLists",
                columns: table => new
                {
                    FieldCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CARTableId = table.Column<int>(type: "int", nullable: false),
                    SignTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormNameFa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARCartableLists");

            migrationBuilder.RenameColumn(
                name: "FormNameFa",
                table: "AdminForms",
                newName: "FormNameFarsi");
        }
    }
}
