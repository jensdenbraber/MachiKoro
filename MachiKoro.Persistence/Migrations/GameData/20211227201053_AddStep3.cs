using Microsoft.EntityFrameworkCore.Migrations;

namespace MachiKoro.Data.Migrations.GameData
{
    public partial class AddStep3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoiseType",
                table: "Steps",
                newName: "ChoiceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoiceType",
                table: "Steps",
                newName: "ChoiseType");
        }
    }
}
