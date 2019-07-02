using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Data.Migrations
{
    public partial class changedModelPaymentTypeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PaymentTypeLocation_PaymentTypeLocationId",
                table: "PaymentTypeLocation");

            migrationBuilder.DropColumn(
                name: "PaymentTypeLocationId",
                table: "PaymentTypeLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeLocationId",
                table: "PaymentTypeLocation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PaymentTypeLocation_PaymentTypeLocationId",
                table: "PaymentTypeLocation",
                column: "PaymentTypeLocationId");
        }
    }
}
