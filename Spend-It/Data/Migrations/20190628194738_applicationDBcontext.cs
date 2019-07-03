using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Data.Migrations
{
    public partial class applicationDBcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypeLocation",
                table: "PaymentTypeLocation");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypeLocation_PaymentTypeId",
                table: "PaymentTypeLocation");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeLocationId",
                table: "PaymentTypeLocation",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PaymentTypeLocation_PaymentTypeLocationId",
                table: "PaymentTypeLocation",
                column: "PaymentTypeLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypeLocation",
                table: "PaymentTypeLocation",
                columns: new[] { "PaymentTypeId", "LocationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PaymentTypeLocation_PaymentTypeLocationId",
                table: "PaymentTypeLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypeLocation",
                table: "PaymentTypeLocation");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeLocationId",
                table: "PaymentTypeLocation",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypeLocation",
                table: "PaymentTypeLocation",
                column: "PaymentTypeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeLocation_PaymentTypeId",
                table: "PaymentTypeLocation",
                column: "PaymentTypeId");
        }
    }
}
