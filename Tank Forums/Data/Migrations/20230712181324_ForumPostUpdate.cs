using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class ForumPostUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "classIcon",
                table: "ForumPost");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ForumPost",
                newName: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "ForumPost",
                newName: "Id");

            migrationBuilder.AddColumn<byte[]>(
                name: "classIcon",
                table: "ForumPost",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
