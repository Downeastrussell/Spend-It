using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Data.Migrations
{
    public partial class testremoveJoinTableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTypeLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTypeLocation",
                columns: table => new
                {
                    PaymentTypeLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeLocation", x => x.PaymentTypeLocationId);
                    table.ForeignKey(
                        name: "FK_PaymentTypeLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTypeLocation_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeLocation_LocationId",
                table: "PaymentTypeLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeLocation_PaymentTypeId",
                table: "PaymentTypeLocation",
                column: "PaymentTypeId");
        }
    }
}
