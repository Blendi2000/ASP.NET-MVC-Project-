using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GymWebApplication1.Data.Migrations
{
    public partial class Trainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerName = table.Column<string>(nullable: true),
                    TrainerLastName = table.Column<string>(nullable: true),
                    TrainerAddress = table.Column<string>(nullable: true),
                    TrainerContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TrainerId",
                table: "Schedules",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
