using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationWithAuth.Migrations
{
    public partial class AddIsDeletedToFoodAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FoodAssignments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FoodAssignments");
        }
    }
}
