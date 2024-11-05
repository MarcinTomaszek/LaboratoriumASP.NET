using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth", "Category", "Created", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(2003, 3, 18), 2, new DateTime(2024, 11, 5, 18, 1, 46, 128, DateTimeKind.Local).AddTicks(6238), "LukasJanus@microsoft.wsei.edu.pl", "Lukas", "Janus", "607 758 331" },
                    { 2, new DateOnly(2003, 7, 18), 2, new DateTime(2024, 11, 5, 18, 1, 46, 128, DateTimeKind.Local).AddTicks(6282), "PawelWrona@microsoft.wsei.edu.pl", "Pawel", "Wrona", "111 222 333" },
                    { 3, new DateOnly(2005, 3, 18), 2, new DateTime(2024, 11, 5, 18, 1, 46, 128, DateTimeKind.Local).AddTicks(6285), "KacperWojas@microsoft.wsei.edu.pl", "Kacper", "Wojas", "412 123 123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
