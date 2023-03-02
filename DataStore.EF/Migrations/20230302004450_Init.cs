using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStore.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Owner = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ReportDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[] { 1, "Project 1" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[] { 2, "Project 2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 1, null, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frank Liu", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bug #1" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 2, null, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", 1, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bug #2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 5, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chua Lee", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swagger bug" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 3, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Dela Cruz", 2, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bug #3" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 4, "A new bug", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Dela Cruz", 2, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another Bug" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[] { 6, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Jackson", 2, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another Swagger bug" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
