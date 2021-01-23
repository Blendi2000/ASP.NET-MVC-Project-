using Microsoft.EntityFrameworkCore.Migrations;

namespace GymWebApplication1.Data.Migrations
{
    public partial class Projekttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipPhoneNumber",
                table: "Membership");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Membership",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Membership");

            migrationBuilder.AddColumn<string>(
                name: "MembershipPhoneNumber",
                table: "Membership",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
