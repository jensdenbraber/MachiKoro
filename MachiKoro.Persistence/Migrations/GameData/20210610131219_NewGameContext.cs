using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class NewGameContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesLost",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GamesWon",
                table: "Player");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerProfileId",
                table: "Player",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Player",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PlayerProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PlayersStatisticsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlayerProfileId",
                table: "Player",
                column: "PlayerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_PlayerProfile_PlayerProfileId",
                table: "Player",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_PlayerProfile_PlayerProfileId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "PlayerProfile");

            migrationBuilder.DropIndex(
                name: "IX_Player_PlayerProfileId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PlayerProfileId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "GamesLost",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesWon",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
