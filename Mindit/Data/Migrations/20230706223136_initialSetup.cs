using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class initialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classIcon = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    postDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    postTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postLikes = table.Column<int>(type: "int", nullable: false),
                    postDislikes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPost", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumPost");
        }
    }
}
