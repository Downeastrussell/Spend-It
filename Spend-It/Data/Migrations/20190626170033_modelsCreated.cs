using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Data.Migrations
{
    public partial class modelsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    LocationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationTypeName = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.LocationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    LocationName = table.Column<string>(maxLength: 55, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    LocationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "LocationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentTypeName = table.Column<string>(maxLength: 55, nullable: false),
                    PaymentTypeTicker = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_PaymentType_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedLocation",
                columns: table => new
                {
                    SavedLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedLocation", x => x.SavedLocationId);
                    table.ForeignKey(
                        name: "FK_SavedLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedLocation_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypeLocation",
                columns: table => new
                {
                    PaymentTypeLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
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
                name: "IX_Location_CityId",
                table: "Location",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationTypeId",
                table: "Location",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UserId",
                table: "Location",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_LocationId",
                table: "PaymentType",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeLocation_LocationId",
                table: "PaymentTypeLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeLocation_PaymentTypeId",
                table: "PaymentTypeLocation",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedLocation_LocationId",
                table: "SavedLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedLocation_UserId1",
                table: "SavedLocation",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTypeLocation");

            migrationBuilder.DropTable(
                name: "SavedLocation");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
