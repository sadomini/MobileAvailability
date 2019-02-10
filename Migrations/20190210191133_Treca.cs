using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileAvailability.Migrations
{
    public partial class Treca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProizvodjacId = table.Column<int>(nullable: false),
                    Tip = table.Column<string>(nullable: false),
                    TrgovinaId = table.Column<int>(nullable: false),
                    PredajaOglasa = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<float>(nullable: false),
                    Dostupnost = table.Column<bool>(nullable: false),
                    Kontakt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Producer_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Availabilities_Market_TrgovinaId",
                        column: x => x.TrgovinaId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_ProizvodjacId",
                table: "Availabilities",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_TrgovinaId",
                table: "Availabilities",
                column: "TrgovinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");
        }
    }
}
