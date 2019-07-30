using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectsManagement.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programmers",
                columns: table => new
                {
                    ProgrammerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmers", x => x.ProgrammerID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    FullDescription = table.Column<string>(maxLength: 300, nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProgrammers",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    ProgrammerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProgrammers", x => new { x.ProjectID, x.ProgrammerID });
                    table.ForeignKey(
                        name: "FK_ProjectProgrammers_Programmers_ProgrammerID",
                        column: x => x.ProgrammerID,
                        principalTable: "Programmers",
                        principalColumn: "ProgrammerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProgrammers_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programmers",
                columns: new[] { "ProgrammerID", "BirthDate", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[,]
                {
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2002), "bojack@mail.com", "BoJack", "https://localhost:44340/images/bojack.jpg", "Horseman", "+ 11 111 11 11 111" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen@mail.com", "Diane", "https://localhost:44340/images/diane.jpg", "Nguyen", "+22 222 22 22 222" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chavez@mail.com", "Todd", "https://localhost:44340/images/todd.jpg", "Chavez", "+33 333 33 33 333" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "peanutbutter@mail.com", "Mr.", "https://localhost:44340/images/peanutbutter.jpg", "Peanutbutter", "+44 444 44 44 444" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "carolyn@mail.com", "Princess", "https://localhost:44340/images/carolyn.jpg", "Carolyn", "+55 555 55 55 555" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mannowdog@mail.com", "Judah", "https://localhost:44340/images/mannowdog.jpg", "Mannowdog", "+66 666 66 66 666" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Description", "FullDescription", "Name" },
                values: new object[] { 100, "Shord description for project", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.", "First Project" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Description", "FullDescription", "Name" },
                values: new object[] { 101, "Shord description for project", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.", "Second Project" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Description", "FullDescription", "Name" },
                values: new object[] { 102, "Shord description for project", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.", "Third Project" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Description", "FullDescription", "Name" },
                values: new object[] { 103, "Shord description for project", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.", "Fourth Project" });

            migrationBuilder.InsertData(
                table: "ProjectProgrammers",
                columns: new[] { "ProjectID", "ProgrammerID" },
                values: new object[,]
                {
                    { 100, 100 },
                    { 100, 102 },
                    { 100, 104 },
                    { 101, 101 },
                    { 101, 103 },
                    { 101, 105 },
                    { 102, 100 },
                    { 102, 102 },
                    { 102, 104 },
                    { 103, 102 },
                    { 103, 105 },
                    { 103, 104 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProgrammers_ProgrammerID",
                table: "ProjectProgrammers",
                column: "ProgrammerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProgrammers");

            migrationBuilder.DropTable(
                name: "Programmers");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
