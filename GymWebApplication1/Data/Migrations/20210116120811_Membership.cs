using Microsoft.EntityFrameworkCore.Migrations;

namespace GymWebApplication1.Data.Migrations
{
    public partial class Membership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipName = table.Column<string>(nullable: true),
                    MembershipPhoneNumber = table.Column<string>(nullable: true),
                    MembershipAge = table.Column<int>(nullable: false),
                    MembershipBill = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");
        }
    }
}
