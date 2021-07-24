using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class NewGameContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Games_GameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Player");

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => new { x.GamesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_GamePlayer_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Player_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayersId",
                table: "GamePlayer",
                column: "PlayersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Player",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Games_GameId",
                table: "Player",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
