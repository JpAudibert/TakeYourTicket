using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeYourTicket.Migrations
{
    public partial class CreateSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Movie",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Movie",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExhibitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Movie",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Movie",
                newName: "createdAt");
        }
    }
}
