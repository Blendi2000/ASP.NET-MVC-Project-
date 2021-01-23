using Microsoft.EntityFrameworkCore.Migrations;

namespace GymWebApplication1.Data.Migrations
{
    public partial class Regular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MEmail",
                table: "Membership",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MEmail",
                table: "Membership",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
