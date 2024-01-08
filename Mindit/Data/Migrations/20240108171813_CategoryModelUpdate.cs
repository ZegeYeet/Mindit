using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindit.Data.Migrations
{
    public partial class CategoryModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "categoryActive",
                table: "MinditCategoryModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "categoryCreator",
                table: "MinditCategoryModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categoryDescription",
                table: "MinditCategoryModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "creationDate",
                table: "MinditCategoryModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryActive",
                table: "MinditCategoryModel");

            migrationBuilder.DropColumn(
                name: "categoryCreator",
                table: "MinditCategoryModel");

            migrationBuilder.DropColumn(
                name: "categoryDescription",
                table: "MinditCategoryModel");

            migrationBuilder.DropColumn(
                name: "creationDate",
                table: "MinditCategoryModel");
        }
    }
}
