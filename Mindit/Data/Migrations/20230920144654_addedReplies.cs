using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class addedReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumReply",
                columns: table => new
                {
                    ReplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    replyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    replyBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    replyLikes = table.Column<int>(type: "int", nullable: false),
                    replyDislikes = table.Column<int>(type: "int", nullable: false),
                    ForumPostPostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumReply", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_ForumReply_ForumPost_ForumPostPostId",
                        column: x => x.ForumPostPostId,
                        principalTable: "ForumPost",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumReply_ForumPostPostId",
                table: "ForumReply",
                column: "ForumPostPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumReply");
        }
    }
}
