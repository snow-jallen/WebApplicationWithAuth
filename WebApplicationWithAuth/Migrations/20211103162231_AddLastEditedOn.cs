using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationWithAuth.Migrations
{
    public partial class AddLastEditedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedOn",
                table: "FoodAssignments",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEditedOn",
                table: "FoodAssignments");
        }
    }
}
