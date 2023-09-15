using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class MinditCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MinditCategoryModel",
                columns: table => new
                {
                    categoryName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinditCategoryModel", x => x.categoryName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MinditCategoryModel");
        }
    }
}
