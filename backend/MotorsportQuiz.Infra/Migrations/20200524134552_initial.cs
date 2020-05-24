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
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[] { new Guid("8efb81c1-ef1e-48d1-89ba-97bdcb6e26e7"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), false, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("75080270-7c4b-4eae-bcef-5c32122acaa6"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("7a87c0aa-057d-451b-865e-67f87401b46d"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), true, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("780681e5-83b7-4fd3-8f18-1650eaf8f2dd"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("66b7e245-de57-4e81-901e-8fd930995876"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("8b8ba378-ace3-4d79-acf8-594545ba3adc"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), true, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("d84ae0b2-f7d0-4ef1-9fe1-62910bcd319f"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), false, new Guid("a6c4affe-770d-4258-8906-eb5707756c94") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("3208939f-49a4-4784-8890-697eb59343d1"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("f1e0dc25-2c37-4a86-8cf0-6ee5eea3a2f2"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("aabc2ed9-2af8-4647-8c53-81583d3c76c8"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("9fca647a-390c-4b9a-80e5-b1bbc4efb91f"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), true, new Guid("473d113f-0279-422a-afb3-6533908df4b9") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("3376fd44-83f1-4659-a42b-85e016009bb8"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), true, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("f7cfb9f5-24cf-47e1-89ef-10b2406f7a95"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("f74f1c10-e9ac-4011-8460-2ec93e495da9"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("7f1fe989-a7e6-4b78-9c97-8541962ded6a"), new Guid("e987dd39-b377-4df0-9b4f-d70538121d70"), false, new Guid("3eb99380-568e-449d-842c-d997a56875c0") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("58ac5e95-2153-4e8a-b5b3-2d347c9a2b21"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("a386f5d1-741c-40c7-8f2f-b3ace486516d"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), true, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("1dbdaf37-e5dc-42d7-be60-35f07e82e62b"), new Guid("fe5e1bbc-edd7-4153-81a2-add6908b0b1f"), false, new Guid("46800301-9e10-44ce-80ee-c5097e69080a") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("29bb073d-d5a8-4cf8-9040-a76bb7c82b69"), new Guid("4ef0f07c-2450-454f-8364-f6703621fb3b"), false, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "AnswerId", "Correct", "QuestionId" },
                values: new object[] { new Guid("53fee0eb-c09d-423f-9b06-0bb1ee3229d8"), new Guid("74d4504d-f55b-49a6-b35e-19b90abb8904"), false, new Guid("296b4c6f-9dff-492b-90f2-4bcb7d7344cb") });

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
