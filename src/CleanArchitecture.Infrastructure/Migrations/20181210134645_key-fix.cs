using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class keyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTrainings",
                table: "PlayerTrainings");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTrainings_PlayerId",
                table: "PlayerTrainings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayerTrainings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTrainings",
                table: "PlayerTrainings",
                columns: new[] { "PlayerId", "TrainingId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTrainings",
                table: "PlayerTrainings");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlayerTrainings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTrainings",
                table: "PlayerTrainings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTrainings_PlayerId",
                table: "PlayerTrainings",
                column: "PlayerId");
        }
    }
}
