using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class datatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_GamesId",
                table: "GamePlayer",
                column: "GamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GamePlayer_GamesId",
                table: "GamePlayer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer",
                columns: new[] { "GamesId", "PlayersId" });
        }
    }
}
