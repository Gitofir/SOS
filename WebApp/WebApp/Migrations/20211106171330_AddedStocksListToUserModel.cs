using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddedStocksListToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Stock",
                type: "nvarchar(40)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Username",
                table: "Stock",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_User_Username",
                table: "Stock",
                column: "Username",
                principalTable: "User",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_User_Username",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_Username",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Stock");
        }
    }
}
