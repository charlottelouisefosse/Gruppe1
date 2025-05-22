using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe1.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelToPollenRegistering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlantName",
                table: "PollenRegistrations");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "PollenRegistrations",
                newName: "Level");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfPollen",
                table: "PollenRegistrations",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfPollen",
                table: "PollenRegistrations");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "PollenRegistrations",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "PlantName",
                table: "PollenRegistrations",
                type: "TEXT",
                nullable: true);
        }
    }
}
