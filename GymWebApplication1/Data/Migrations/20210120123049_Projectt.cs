using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GymWebApplication1.Data.Migrations
{
    public partial class Projectt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Membership",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Membership",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Membership",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Membership",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Membership");
        }
    }
}
