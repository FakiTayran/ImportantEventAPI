using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportantEventDataAccess.Migrations
{
    public partial class LanguageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Events");
        }
    }
}
