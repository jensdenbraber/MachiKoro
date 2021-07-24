using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations
{
    public partial class NewPlayerContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesLost",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GamesWon",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerProfileId",
                table: "Players",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Players",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PlayersProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PlayersStatisticsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false),
                    GamesWon = table.Column<int>(nullable: false),
                    GamesLost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStatistics", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayersProfiles_PlayerProfileId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayersProfiles");

            migrationBuilder.DropTable(
                name: "PlayersStatistics");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerProfileId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerProfileId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "GamesLost",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesWon",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
