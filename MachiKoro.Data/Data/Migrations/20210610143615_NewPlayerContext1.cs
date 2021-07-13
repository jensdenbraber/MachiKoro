using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations
{
    public partial class NewPlayerContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayersProfiles_PlayerProfileId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerProfileId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayersStatisticsId",
                table: "PlayersProfiles");

            migrationBuilder.DropColumn(
                name: "PlayerProfileId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PlayersStatistics",
                newName: "PlayerProfileForeignKey");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PlayersProfiles",
                newName: "PlayerForeignKey");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpensionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStatistics_PlayerProfileForeignKey",
                table: "PlayersStatistics",
                column: "PlayerProfileForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersProfiles_PlayerForeignKey",
                table: "PlayersProfiles",
                column: "PlayerForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayersId",
                table: "GamePlayer",
                column: "PlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersProfiles_Players_PlayerForeignKey",
                table: "PlayersProfiles",
                column: "PlayerForeignKey",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersStatistics_PlayersProfiles_PlayerProfileForeignKey",
                table: "PlayersStatistics",
                column: "PlayerProfileForeignKey",
                principalTable: "PlayersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersProfiles_Players_PlayerForeignKey",
                table: "PlayersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersStatistics_PlayersProfiles_PlayerProfileForeignKey",
                table: "PlayersStatistics");

            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_PlayersStatistics_PlayerProfileForeignKey",
                table: "PlayersStatistics");

            migrationBuilder.DropIndex(
                name: "IX_PlayersProfiles_PlayerForeignKey",
                table: "PlayersProfiles");

            migrationBuilder.RenameColumn(
                name: "PlayerProfileForeignKey",
                table: "PlayersStatistics",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PlayerForeignKey",
                table: "PlayersProfiles",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayersStatisticsId",
                table: "PlayersProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerProfileId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerProfileId",
                table: "Players",
                column: "PlayerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayersProfiles_PlayerProfileId",
                table: "Players",
                column: "PlayerProfileId",
                principalTable: "PlayersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
