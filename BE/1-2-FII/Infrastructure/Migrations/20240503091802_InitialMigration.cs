using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerAssignmentRespondedId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerStudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerContent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentQuestion = table.Column<string>(type: "text", nullable: false),
                    AssignmentCode = table.Column<string>(type: "text", nullable: false),
                    AssignmentCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentAnswersId = table.Column<List<Guid>>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseName = table.Column<string>(type: "text", nullable: false),
                    CourseDescription = table.Column<string>(type: "text", nullable: false),
                    CourseSemester = table.Column<int>(type: "integer", nullable: false),
                    CourseNrOfCredits = table.Column<int>(type: "integer", nullable: false),
                    CourseWebsite = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceName = table.Column<string>(type: "text", nullable: false),
                    ResourceDescription = table.Column<string>(type: "text", nullable: false),
                    ResourceType = table.Column<string>(type: "text", nullable: false),
                    ResourcePrerequisites = table.Column<string>(type: "text", nullable: false),
                    ResourceFileContent = table.Column<byte[]>(type: "bytea", nullable: false),
                    ResourceCourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
