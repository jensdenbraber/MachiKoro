using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations
{
    public partial class InitialCreateNewLayout11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "PlayersStatistics");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "PlayersProfiles");

            migrationBuilder.DropTable(
                name: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpensionType = table.Column<int>(type: "int", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "PlayersProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerForeignKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersProfiles_Players_PlayerForeignKey",
                        column: x => x.PlayerForeignKey,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesLost = table.Column<int>(type: "int", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    GamesWon = table.Column<int>(type: "int", nullable: false),
                    PlayerProfileForeignKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersStatistics_PlayersProfiles_PlayerProfileForeignKey",
                        column: x => x.PlayerProfileForeignKey,
                        principalTable: "PlayersProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayersId",
                table: "GamePlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersProfiles_PlayerForeignKey",
                table: "PlayersProfiles",
                column: "PlayerForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStatistics_PlayerProfileForeignKey",
                table: "PlayersStatistics",
                column: "PlayerProfileForeignKey",
                unique: true);
        }
    }
}
