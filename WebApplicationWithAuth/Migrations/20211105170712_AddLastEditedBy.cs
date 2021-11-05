using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationWithAuth.Migrations
{
    public partial class AddLastEditedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastEditedBy",
                table: "Parties",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEditedBy",
                table: "Parties");
        }
    }
}
