using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class carddecks1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StartingEstablishments",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartingLandmarks",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingEstablishments",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StartingLandmarks",
                table: "Games");
        }
    }
}
