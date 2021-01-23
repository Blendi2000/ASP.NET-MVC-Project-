using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GymWebApplication1.Data.Migrations
{
    public partial class Initinial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships");

            migrationBuilder.RenameTable(
                name: "Memberships",
                newName: "Membership");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Membership",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Membership",
                table: "Membership",
                column: "MembershipId");

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dueDate = table.Column<DateTime>(nullable: false),
                    paidDate = table.Column<DateTime>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: true),
                    MembershipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_MembershipId",
                table: "Bill",
                column: "MembershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Membership",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Membership");

            migrationBuilder.RenameTable(
                name: "Membership",
                newName: "Memberships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships",
                column: "MembershipId");
        }
    }
}
