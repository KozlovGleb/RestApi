using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.DataAccess.Migrations
{
    public partial class AddedRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Entities",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ToDo",
                table: "Entities",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ToDo",
                table: "Entities");
        }
    }
}
