using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HS4_Dergi_Web_Api.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Concessionaire = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    JournalType = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Editor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 4, nullable: false),
                    Page = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalSeries_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalSeriesId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_JournalSeries_JournalSeriesId",
                        column: x => x.JournalSeriesId,
                        principalTable: "JournalSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Monique Lakin" },
                    { 19, "Karley Kovacek" },
                    { 18, "Marlen O'Conner" },
                    { 17, "Morgan Abernathy" },
                    { 16, "Julio Harber" },
                    { 15, "Robbie Tromp" },
                    { 14, "Melany Kub" },
                    { 13, "Jerel Bergnaum" },
                    { 12, "Jeremie Miller" },
                    { 11, "Winfield Davis" },
                    { 20, "Dolores Rodriguez" },
                    { 9, "Obie Windler" },
                    { 8, "Marjolaine Reichel" },
                    { 7, "Alice Jones" },
                    { 6, "Alda Bradtke" },
                    { 5, "Elmer Mann" },
                    { 4, "Enrique Kiehn" },
                    { 3, "Emmet Gerlach" },
                    { 2, "Cristina Mills" },
                    { 10, "Georgiana Balistreri" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Lempi Jakubowski" },
                    { 13, "Alicia Predovic" },
                    { 14, "Gabe Barton" },
                    { 18, "Shany Nikolaus" },
                    { 16, "Chadrick Gulgowski" },
                    { 17, "Maudie Nienow" },
                    { 11, "Katrine Spencer" },
                    { 15, "Myah Bartoletti" },
                    { 10, "Bernardo Gerhold" },
                    { 6, "Joannie Goldner" },
                    { 8, "Geoffrey Lockman" },
                    { 7, "Jacques Miller" },
                    { 5, "Jessika Welch" },
                    { 4, "Zora Gutkowski" },
                    { 3, "Gabrielle Effertz" },
                    { 2, "Juwan Becker" },
                    { 1, "Buddy Heathcote" },
                    { 19, "Lynn Kiehn" },
                    { 9, "Adonis Morissette" },
                    { 20, "Danika Grady" }
                });

            migrationBuilder.InsertData(
                table: "Journals",
                columns: new[] { "Id", "Concessionaire", "JournalType", "Name", "Period", "PublisherId" },
                values: new object[,]
                {
                    { 12, "Kade Schuster", 1, "Kareem", 3, 1 },
                    { 20, "Paris Pacocha", 2, "Taylor", 1, 18 },
                    { 16, "Eunice Medhurst", 5, "Eloisa", 1, 16 },
                    { 5, "Cordelia Mayer", 5, "Odie", 4, 15 },
                    { 8, "Lavern Hyatt", 2, "Harold", 5, 14 },
                    { 19, "Roger Lubowitz", 6, "Mayra", 3, 12 },
                    { 9, "Kory Turcotte", 4, "Imogene", 3, 12 },
                    { 4, "Marguerite Spencer", 6, "Adriel", 3, 10 },
                    { 17, "Kacie Hermiston", 2, "Renee", 4, 9 },
                    { 1, "Gus Wyman", 6, "Aniya", 2, 6 },
                    { 7, "Michale Anderson", 5, "Ruthe", 5, 5 },
                    { 18, "Grant Collins", 6, "Sallie", 3, 4 },
                    { 10, "Baron Spencer", 4, "Ike", 1, 4 },
                    { 14, "Judy Goldner", 6, "Anthony", 2, 3 },
                    { 6, "Kiana Howell", 5, "Stacey", 1, 3 },
                    { 3, "Adolf Dickinson", 2, "Foster", 4, 3 },
                    { 15, "Garrett Corkery", 6, "Rogers", 2, 2 },
                    { 11, "Amber Johns", 6, "Marilyne", 2, 2 },
                    { 2, "Brenden Mraz", 1, "Sasha", 4, 19 },
                    { 13, "Darrell Stanton", 4, "Bette", 3, 20 }
                });

            migrationBuilder.InsertData(
                table: "JournalSeries",
                columns: new[] { "Id", "Editor", "JournalId", "Page", "Price", "PublicationDate" },
                values: new object[,]
                {
                    { 6, "Vivianne Wilkinson", 11, 39, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Jeramy Kulas", 20, 59, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Kameron Kertzmann", 20, 93, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Alexa Wuckert", 20, 30, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Crawford Kemmer", 17, 57, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Skylar Kuvalis", 1, 64, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Deonte Cole", 1, 76, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Brennon Bins", 1, 85, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Kiley Mills", 7, 43, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Emmalee Wisozk", 18, 66, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Eric Shields", 18, 73, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Leonora Ritchie", 18, 88, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Oliver Bayer", 14, 83, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Myrna Braun", 6, 60, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Walton Feil", 3, 67, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Angela Lesch", 15, 48, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Terrill Quigley", 15, 40, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Sylvia Haley", 11, 37, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Dwight Block", 20, 93, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Isidro Carroll", 13, 34, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Description", "Image", "JournalSeriesId", "Title" },
                values: new object[,]
                {
                    { 5, 12, "Product", null, 1, "District Configuration Coordinator" },
                    { 9, 17, "Dynamic", null, 14, "Corporate Optimization Executive" },
                    { 2, 9, "District", null, 14, "Future Group Planner" },
                    { 1, 12, "Internal", null, 9, "Corporate Directives Manager" },
                    { 11, 8, "Customer", null, 7, "Lead Usability Facilitator" },
                    { 12, 17, "Forward", null, 5, "Global Mobility Manager" },
                    { 3, 15, "Lead", null, 5, "Chief Identity Assistant" },
                    { 18, 14, "Human", null, 16, "Legacy Identity Developer" },
                    { 20, 13, "Forward", null, 20, "Forward Communications Consultant" },
                    { 19, 15, "Product", null, 20, "Forward Security Administrator" },
                    { 8, 20, "Principal", null, 20, "Global Accountability Administrator" },
                    { 7, 20, "Customer", null, 3, "Dynamic Operations Engineer" },
                    { 4, 8, "Corporate", null, 19, "Dynamic Creative Supervisor" },
                    { 17, 9, "Senior", null, 4, "Future Metrics Analyst" },
                    { 15, 4, "District", null, 2, "Chief Group Manager" },
                    { 14, 4, "District", null, 2, "Global Applications Agent" },
                    { 16, 11, "Customer", null, 1, "Future Factors Executive" },
                    { 6, 3, "Dynamic", null, 1, "Senior Brand Executive" },
                    { 10, 9, "Product", null, 14, "Principal Program Consultant" },
                    { 13, 13, "Human", null, 11, "Principal Security Facilitator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_JournalSeriesId",
                table: "Articles",
                column: "JournalSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_PublisherId",
                table: "Journals",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalSeries_JournalId",
                table: "JournalSeries",
                column: "JournalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "JournalSeries");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
