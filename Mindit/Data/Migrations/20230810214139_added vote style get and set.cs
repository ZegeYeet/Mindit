using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class addedvotestylegetandset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "voteStyle",
                table: "PostVotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "voteStyle",
                table: "PostVotes");
        }
    }
}
