using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GymWebApplication1.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserLastname = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserContact = table.Column<string>(nullable: true),
                    UserAddress = table.Column<string>(nullable: true),
                    UserJoinDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
