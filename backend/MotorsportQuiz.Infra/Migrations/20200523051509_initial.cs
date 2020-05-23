using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorsportQuiz.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Result = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    Correct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), "Inglaterra" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), "USA" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), "Alemanha" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), "Japão" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("46800301-9e10-44ce-80ee-c5097e69080a"), "BMW" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3eb99380-568e-449d-842c-d997a56875c0"), "Toyota" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("473d113f-0279-422a-afb3-6533908df4b9"), "Mini" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a6c4affe-770d-4258-8906-eb5707756c94"), "General Motors" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb"), "Rolls-Royce" });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("9442a0a7-5aed-46c4-949b-b187113f3655"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), false, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("79cf6e43-0bc6-460d-87a9-38091ad32c14"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("2d879fe5-bd54-4aad-9941-2c6cb5f61776"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), true, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("c0efa554-fee2-4e8e-bcdd-9a60e3749557"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("dd18653a-b22c-44f5-8f5d-95ed6b4c2aad"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("5083dd2b-fabf-448c-982c-8a7e6fec347d"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), true, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("bc76d353-e141-490f-9895-5fbcb8696e1c"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), false, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("edc6191c-5e29-48cf-a639-3fbc8d8e0346"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("22d7c535-c2bc-459a-9489-7374f4da2bd0"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("dede8d12-5edd-449f-bad8-03fa2fff2dc5"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("d9220995-1c20-4767-aa18-5ecdd2516a15"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), true, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("4aeed317-c192-486c-89e2-d98a7d6c8ea2"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), true, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("c3afe181-b3cf-4c7c-bc06-6232066c488d"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("85ed90d3-19cf-4d2b-bd76-8dcffda82c1d"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("dd9dc0ba-87a7-412f-96ac-a03cdd8be170"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), false, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("0b07d90f-bf4e-4dab-9f1d-384ad2ebb07a"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("950f98e1-02cf-4d0f-b493-5a59324c38a1"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), true, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("a541be38-14a2-4d0c-a7bf-0525b290f638"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("ebafa428-9c75-4f7e-9b66-833845580080"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("73c81d70-1a13-4511-878b-0428c0de83da"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_AnswerId",
                table: "QuestionAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_QuestionId",
                table: "QuestionAnswers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
