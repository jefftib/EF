using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Stamnummer = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Bijnaam = table.Column<string>(nullable: true),
                    Trainer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Stamnummer);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    SpelerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(nullable: true),
                    rugnummer = table.Column<int>(nullable: false),
                    value = table.Column<double>(nullable: false),
                    TeamStamnummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.SpelerId);
                    table.ForeignKey(
                        name: "FK_Spelers_Teams_TeamStamnummer",
                        column: x => x.TeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpelerId = table.Column<int>(nullable: true),
                    Prijs = table.Column<double>(nullable: false),
                    OudeClubStamnummer = table.Column<int>(nullable: true),
                    NieuweClubStamnummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_NieuweClubStamnummer",
                        column: x => x.NieuweClubStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_OudeClubStamnummer",
                        column: x => x.OudeClubStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Spelers_SpelerId",
                        column: x => x.SpelerId,
                        principalTable: "Spelers",
                        principalColumn: "SpelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_TeamStamnummer",
                table: "Spelers",
                column: "TeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_NieuweClubStamnummer",
                table: "Transfers",
                column: "NieuweClubStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_OudeClubStamnummer",
                table: "Transfers",
                column: "OudeClubStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SpelerId",
                table: "Transfers",
                column: "SpelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
