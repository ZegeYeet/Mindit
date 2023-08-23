using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class removedacctforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostVotes_AspNetUsers_Name",
                table: "PostVotes");

            migrationBuilder.DropIndex(
                name: "IX_PostVotes_Name",
                table: "PostVotes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PostVotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PostVotes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostVotes_Name",
                table: "PostVotes",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_PostVotes_AspNetUsers_Name",
                table: "PostVotes",
                column: "Name",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
