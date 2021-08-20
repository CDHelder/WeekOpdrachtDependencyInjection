using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeekOpdrachtDependencyInjection.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseDate", "Title" },
                values: new object[] { 1, new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaws" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseDate", "Title" },
                values: new object[] { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luca" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseDate", "Title" },
                values: new object[] { 3, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kill Bill" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
