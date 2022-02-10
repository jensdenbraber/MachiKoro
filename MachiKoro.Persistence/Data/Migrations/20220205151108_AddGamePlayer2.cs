using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations
{
    public partial class AddGamePlayer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Players_PlayerId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_PlayerId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Game");

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
                        name: "FK_GamePlayer_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
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
                name: "PlayerId",
                table: "Game",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerId",
                table: "Game",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Players_PlayerId",
                table: "Game",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
