using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.DataAccess.Migrations
{
    public partial class _1tm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Entities",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_UserId",
                table: "Entities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Users_UserId",
                table: "Entities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Users_UserId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_UserId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Entities");
        }
    }
}
