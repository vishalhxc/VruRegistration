using Microsoft.EntityFrameworkCore.Migrations;

namespace VruRegistrationApi.Migrations
{
    public partial class AddScheduleToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Courses",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Courses");
        }
    }
}
