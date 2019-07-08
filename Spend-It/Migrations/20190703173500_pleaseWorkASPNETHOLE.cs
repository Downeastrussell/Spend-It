using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Migrations
{
    public partial class pleaseWorkASPNETHOLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sneakyStuff",
                table: "LocationType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sneakyStuff",
                table: "LocationType",
                nullable: true);
        }
    }
}
