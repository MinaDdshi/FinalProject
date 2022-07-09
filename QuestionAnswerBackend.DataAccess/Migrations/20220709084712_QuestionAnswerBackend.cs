using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionAnswerBackend.DataAccess.Migrations
{
    public partial class QuestionAnswerBackend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upvote = table.Column<int>(type: "int", nullable: false),
                    Downvote = table.Column<int>(type: "int", nullable: false),
                    RankQuestion = table.Column<int>(type: "int", nullable: false),
                    RankUser = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AnswerContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upvote = table.Column<int>(type: "int", nullable: false),
                    Downvote = table.Column<int>(type: "int", nullable: false),
                    IsCorrectAnswer = table.Column<bool>(type: "bit", nullable: false),
                    RankAnswer = table.Column<int>(type: "int", nullable: false),
                    RankUser = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreationDate", "Family", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8441), "Dadashi", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8441), "Mina" },
                    { 2, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8450), "Mousavi", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8450), "Mahsa" },
                    { 3, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8454), "Abedi", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8454), "Zahra" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreationDate", "Downvote", "LastUpdated", "QuestionContent", "RankQuestion", "RankUser", "Upvote", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9247), 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9247), "This is a Question", 5, 5, 1, 2 },
                    { 2, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9255), 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9255), "This is a Question", 5, 5, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "Description", "LastUpdated", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8351), "Admin of Application", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8351), "Admin" },
                    { 2, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8402), "User of Application", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8402), "User" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerContent", "CreationDate", "Downvote", "IsCorrectAnswer", "LastUpdated", "QuestionId", "RankAnswer", "RankUser", "Upvote", "UserId" },
                values: new object[,]
                {
                    { 1, "This is an Answer", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9282), 1, false, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9282), 1, 5, 5, 1, 2 },
                    { 2, "This is an Answer", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9290), 1, false, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9290), 1, 5, 5, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "CommentQuestions",
                columns: new[] { "Id", "Content", "CreationDate", "LastUpdated", "QuestionId" },
                values: new object[,]
                {
                    { 1, "This is a Comment", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9316), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9316), 1 },
                    { 2, "This is a Comment", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9321), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9321), 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "LastUpdated", "Password", "PersonId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8494), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8494), "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec", 1, "admin" },
                    { 2, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8879), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8879), "594223c6ca4e49db0e6efa915966d9030d84828dfd7f8d095b5cb36f377132b688338f7a8c63fdc06682c8e5e472238e6b1ce6a6aef9df64066d8be02183eb4a", 2, "m.mousavi" },
                    { 3, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8966), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(8966), "a92c94283dabc8bfe1ff978d5900d889f56d173625afbfd512d726fddb57684ef47ac2ab754a696ef185a4c4babf0e1005a2bc27685c228e44f58485f40ec1aa", 3, "z.abedi" }
                });

            migrationBuilder.InsertData(
                table: "CommentAnswers",
                columns: new[] { "Id", "AnswerId", "Content", "CreationDate", "LastUpdated" },
                values: new object[,]
                {
                    { 1, 1, "This is a Comment", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9344), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9344) },
                    { 2, 1, "This is a Comment", new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9349), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9349) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreationDate", "LastUpdated", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9199), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9199), 1, 1 },
                    { 2, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9210), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9210), 2, 2 },
                    { 3, new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9213), new DateTime(2022, 7, 9, 13, 17, 11, 684, DateTimeKind.Local).AddTicks(9213), 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentAnswers_AnswerId",
                table: "CommentAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentQuestions_QuestionId",
                table: "CommentQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentAnswers");

            migrationBuilder.DropTable(
                name: "CommentQuestions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
