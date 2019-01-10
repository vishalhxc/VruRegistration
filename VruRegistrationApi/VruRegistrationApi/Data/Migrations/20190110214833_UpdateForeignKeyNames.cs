using Microsoft.EntityFrameworkCore.Migrations;

namespace VruRegistrationApi.Migrations
{
    public partial class UpdateForeignKeyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorIdId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Semesters_SemesterIdId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseIdID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentIdId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "StudentIdId",
                table: "Enrollments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseIdID",
                table: "Enrollments",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentIdId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseIdID",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseID");

            migrationBuilder.RenameColumn(
                name: "SemesterIdId",
                table: "Courses",
                newName: "SemesterId");

            migrationBuilder.RenameColumn(
                name: "InstructorIdId",
                table: "Courses",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "CreditHours",
                table: "Courses",
                newName: "Credit");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_SemesterIdId",
                table: "Courses",
                newName: "IX_Courses_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorIdId",
                table: "Courses",
                newName: "IX_Courses_InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollments",
                newName: "StudentIdId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Enrollments",
                newName: "CourseIdID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseIdID");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Courses",
                newName: "SemesterIdId");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Courses",
                newName: "InstructorIdId");

            migrationBuilder.RenameColumn(
                name: "Credit",
                table: "Courses",
                newName: "CreditHours");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_SemesterId",
                table: "Courses",
                newName: "IX_Courses_SemesterIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                newName: "IX_Courses_InstructorIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorIdId",
                table: "Courses",
                column: "InstructorIdId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Semesters_SemesterIdId",
                table: "Courses",
                column: "SemesterIdId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseIdID",
                table: "Enrollments",
                column: "CourseIdID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentIdId",
                table: "Enrollments",
                column: "StudentIdId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
