using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class posttracksusernamenotuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostVotes_AspNetUsers_userId",
                table: "PostVotes");

            migrationBuilder.DropIndex(
                name: "IX_PostVotes_userId",
                table: "PostVotes");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "PostVotes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PostVotes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "PostVotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "userName",
                table: "PostVotes");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "PostVotes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PostVotes_userId",
                table: "PostVotes",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostVotes_AspNetUsers_userId",
                table: "PostVotes",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
