using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class nokey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GamePlayer_GamesId",
                table: "GamePlayer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer",
                columns: new[] { "GamesId", "PlayersId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_GamesId",
                table: "GamePlayer",
                column: "GamesId");
        }
    }
}
