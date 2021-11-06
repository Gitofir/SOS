using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
<<<<<<< HEAD:WebApp/WebApp/Migrations/20211016141316_NewMyDB.cs
    public partial class NewMyDB : Migration
||||||| 715c427:WebApp/WebApp/Migrations/MyDBMigrations/20210923202702_Added MyDB for real.cs
    public partial class AddedMyDBforreal : Migration
=======
    public partial class Kahlon : Migration
>>>>>>> 4320a6e5407c08913e0839a22a12c50d294c60db:WebApp/WebApp/Migrations/20211106121823_Kahlon.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Creditcard = table.Column<int>(type: "int", nullable: false),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
