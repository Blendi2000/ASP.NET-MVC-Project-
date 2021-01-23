using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GymWebApplication1.Data.Migrations
{
    public partial class MembershipGym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "MembershipBill",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Bill");

            migrationBuilder.AddColumn<string>(
                name: "MembershipEmail",
                table: "Membership",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageType",
                table: "Membership",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Bill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipEmail",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bill");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Membership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MembershipBill",
                table: "Membership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserJoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }
    }
}
