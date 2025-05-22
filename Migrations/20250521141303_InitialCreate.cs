using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Red = table.Column<float>(type: "REAL", nullable: false),
                    Green = table.Column<float>(type: "REAL", nullable: false),
                    Blue = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DateInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Month = table.Column<int>(type: "INTEGER", nullable: false),
                    Day = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PollenRegistrations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlantName = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenRegistrations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IndexInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    IndexDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ColorInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IndexInfos_ColorInfos_ColorInfoID",
                        column: x => x.ColorInfoID,
                        principalTable: "ColorInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    InSeason = table.Column<bool>(type: "INTEGER", nullable: false),
                    IndexInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantInfos_IndexInfos_IndexInfoID",
                        column: x => x.IndexInfoID,
                        principalTable: "IndexInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollenResponses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateInfoID = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PollenResponses_DateInfos_DateInfoID",
                        column: x => x.DateInfoID,
                        principalTable: "DateInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollenResponses_PlantInfos_PlantInfoID",
                        column: x => x.PlantInfoID,
                        principalTable: "PlantInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndexInfos_ColorInfoID",
                table: "IndexInfos",
                column: "ColorInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantInfos_IndexInfoID",
                table: "PlantInfos",
                column: "IndexInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PollenResponses_DateInfoID",
                table: "PollenResponses",
                column: "DateInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PollenResponses_PlantInfoID",
                table: "PollenResponses",
                column: "PlantInfoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollenRegistrations");

            migrationBuilder.DropTable(
                name: "PollenResponses");

            migrationBuilder.DropTable(
                name: "DateInfos");

            migrationBuilder.DropTable(
                name: "PlantInfos");

            migrationBuilder.DropTable(
                name: "IndexInfos");

            migrationBuilder.DropTable(
                name: "ColorInfos");
        }
    }
}
