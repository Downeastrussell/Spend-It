using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Data.Migrations
{
    public partial class viewModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Location_LocationId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_LocationId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "PaymentType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "PaymentType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_LocationId",
                table: "PaymentType",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Location_LocationId",
                table: "PaymentType",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
