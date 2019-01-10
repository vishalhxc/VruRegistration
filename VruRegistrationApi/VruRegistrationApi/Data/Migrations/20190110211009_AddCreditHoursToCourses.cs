using Microsoft.EntityFrameworkCore.Migrations;

namespace VruRegistrationApi.Migrations
{
    public partial class AddCreditHoursToCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditHours",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "Courses");
        }
    }
}
