using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class GameSteps2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Steps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfPlayers",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steps",
                table: "Steps",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_GameId",
                table: "Steps",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_PlayerId",
                table: "Steps",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Games_GameId",
                table: "Steps",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Player_PlayerId",
                table: "Steps",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Games_GameId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Player_PlayerId",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steps",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_GameId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_PlayerId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "MaxNumberOfPlayers",
                table: "Games");
        }
    }
}
