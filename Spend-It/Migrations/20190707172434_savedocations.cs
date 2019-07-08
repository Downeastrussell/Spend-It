using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spend_It.Migrations
{
    public partial class savedocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedLocation_Location_LocationId",
                table: "SavedLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedLocation",
                table: "SavedLocation");

            migrationBuilder.RenameColumn(
                name: "SavedLocationId",
                table: "SavedLocation",
                newName: "savedLocationId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "SavedLocation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "savedLocationId",
                table: "SavedLocation",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SavedLocationId",
                table: "SavedLocation",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedLocation",
                table: "SavedLocation",
                column: "SavedLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedLocation_Location_LocationId",
                table: "SavedLocation",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedLocation_Location_LocationId",
                table: "SavedLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedLocation",
                table: "SavedLocation");

            migrationBuilder.DropColumn(
                name: "SavedLocationId",
                table: "SavedLocation");

            migrationBuilder.RenameColumn(
                name: "savedLocationId",
                table: "SavedLocation",
                newName: "SavedLocationId");

            migrationBuilder.AlterColumn<int>(
                name: "SavedLocationId",
                table: "SavedLocation",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "SavedLocation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedLocation",
                table: "SavedLocation",
                column: "SavedLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedLocation_Location_LocationId",
                table: "SavedLocation",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
