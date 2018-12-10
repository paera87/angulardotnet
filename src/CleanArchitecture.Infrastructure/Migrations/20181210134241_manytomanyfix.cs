using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class manytomanyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrainings_Players_PlayerId",
                table: "PlayerTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrainings_Trainings_TrainingId",
                table: "PlayerTrainings");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingId",
                table: "PlayerTrainings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerTrainings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrainings_Players_PlayerId",
                table: "PlayerTrainings",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrainings_Trainings_TrainingId",
                table: "PlayerTrainings",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrainings_Players_PlayerId",
                table: "PlayerTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrainings_Trainings_TrainingId",
                table: "PlayerTrainings");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingId",
                table: "PlayerTrainings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerTrainings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrainings_Players_PlayerId",
                table: "PlayerTrainings",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrainings_Trainings_TrainingId",
                table: "PlayerTrainings",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
