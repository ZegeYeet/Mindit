using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class postIdAddToReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumReply_ForumPost_ForumPostPostId",
                table: "ForumReply");

            migrationBuilder.DropIndex(
                name: "IX_ForumReply_ForumPostPostId",
                table: "ForumReply");

            migrationBuilder.DropColumn(
                name: "ForumPostPostId",
                table: "ForumReply");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "ForumReply",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ForumReply_PostId",
                table: "ForumReply",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReply_ForumPost_PostId",
                table: "ForumReply",
                column: "PostId",
                principalTable: "ForumPost",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumReply_ForumPost_PostId",
                table: "ForumReply");

            migrationBuilder.DropIndex(
                name: "IX_ForumReply_PostId",
                table: "ForumReply");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "ForumReply");

            migrationBuilder.AddColumn<int>(
                name: "ForumPostPostId",
                table: "ForumReply",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumReply_ForumPostPostId",
                table: "ForumReply",
                column: "ForumPostPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReply_ForumPost_ForumPostPostId",
                table: "ForumReply",
                column: "ForumPostPostId",
                principalTable: "ForumPost",
                principalColumn: "PostId");
        }
    }
}
