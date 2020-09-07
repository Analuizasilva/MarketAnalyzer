using Microsoft.EntityFrameworkCore.Migrations;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Data.Migrations
{
    public partial class updateUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomTaadasdg",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomTaadasdg",
                table: "AspNetUsers");
        }
    }
}
