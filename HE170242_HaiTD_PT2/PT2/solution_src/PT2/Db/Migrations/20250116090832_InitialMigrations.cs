using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slot3_CodeFirst.Db.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstrumentTypes",
                columns: table => new
                {
                    InstrumentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentTypes", x => x.InstrumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInstrumentTypes",
                columns: table => new
                {
                    PlayerInstrumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    InstrumentTypeId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInstrumentTypes", x => x.PlayerInstrumentId);
                    table.ForeignKey(
                        name: "FK_PlayerInstrumentTypes_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InstrumentTypes",
                columns: new[] { "InstrumentTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Acoustic Guita" },
                    { 2, "Electric Guita" },
                    { 3, "Drums" },
                    { 4, "Bass" },
                    { 5, "Keyboard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInstrumentTypes_PlayerId",
                table: "PlayerInstrumentTypes",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentTypes");

            migrationBuilder.DropTable(
                name: "PlayerInstrumentTypes");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
