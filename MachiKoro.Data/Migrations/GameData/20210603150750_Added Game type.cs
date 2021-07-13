using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class AddedGametype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlayed",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Player",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpensionType",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpensionType",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "IsPlayed",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
