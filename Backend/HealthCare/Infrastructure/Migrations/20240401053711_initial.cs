using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isScorable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssementQuestionsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseType = table.Column<string>(name: "Response_Type", type: "nvarchar(max)", nullable: false),
                    isRequired = table.Column<bool>(type: "bit", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssementQuestionsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssementQuestionsTable_AssessmentsTable_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "AssessmentsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientToAssessmentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientToAssessmentTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentTable_AssessmentsTable_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "AssessmentsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentTable_PatientTable_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsResponseTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Responses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsResponseTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsResponseTable_AssementQuestionsTable_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "AssementQuestionsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientToAssessmentDetailsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientAssessmentId = table.Column<int>(name: "Patient_Assessment_Id", type: "int", nullable: false),
                    QuestionId = table.Column<int>(name: "Question_Id", type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssementQuestionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientToAssessmentDetailsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentDetailsTable_AssementQuestionsTable_AssementQuestionsId",
                        column: x => x.AssementQuestionsId,
                        principalTable: "AssementQuestionsTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentDetailsTable_AssementQuestionsTable_Question_Id",
                        column: x => x.QuestionId,
                        principalTable: "AssementQuestionsTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentDetailsTable_PatientToAssessmentTable_Patient_Assessment_Id",
                        column: x => x.PatientAssessmentId,
                        principalTable: "PatientToAssessmentTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssementQuestionsTable_AssessmentId",
                table: "AssementQuestionsTable",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentDetailsTable_AssementQuestionsId",
                table: "PatientToAssessmentDetailsTable",
                column: "AssementQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentDetailsTable_Patient_Assessment_Id",
                table: "PatientToAssessmentDetailsTable",
                column: "Patient_Assessment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentDetailsTable_Question_Id",
                table: "PatientToAssessmentDetailsTable",
                column: "Question_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentTable_AssessmentId",
                table: "PatientToAssessmentTable",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentTable_PatientId",
                table: "PatientToAssessmentTable",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsResponseTable_QuestionId",
                table: "QuestionsResponseTable",
                column: "QuestionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientToAssessmentDetailsTable");

            migrationBuilder.DropTable(
                name: "QuestionsResponseTable");

            migrationBuilder.DropTable(
                name: "PatientToAssessmentTable");

            migrationBuilder.DropTable(
                name: "AssementQuestionsTable");

            migrationBuilder.DropTable(
                name: "PatientTable");

            migrationBuilder.DropTable(
                name: "AssessmentsTable");
        }
    }
}
