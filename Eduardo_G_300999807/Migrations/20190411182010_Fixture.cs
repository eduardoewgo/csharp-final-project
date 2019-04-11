using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduardo_G_300999807.Migrations
{
    public partial class Fixture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    FixtureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeClubId = table.Column<int>(nullable: true),
                    AwayClubId = table.Column<int>(nullable: true),
                    MatchTime = table.Column<DateTime>(nullable: false),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.FixtureId);
                    table.ForeignKey(
                        name: "FK_Fixtures_Clubs_AwayClubId",
                        column: x => x.AwayClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixtures_Clubs_HomeClubId",
                        column: x => x.HomeClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_AwayClubId",
                table: "Fixtures",
                column: "AwayClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_HomeClubId",
                table: "Fixtures",
                column: "HomeClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");
        }
    }
}
