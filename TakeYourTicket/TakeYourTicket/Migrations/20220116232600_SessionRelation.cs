using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeYourTicket.Migrations
{
    public partial class SessionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Session_MovieId",
                table: "Session",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Movie_MovieId",
                table: "Session",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Movie_MovieId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_MovieId",
                table: "Session");
        }
    }
}
