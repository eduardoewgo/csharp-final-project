using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduardo_G_300999807.Migrations
{
    public partial class TransferLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferLog",
                columns: table => new
                {
                    TransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromClubClubId = table.Column<int>(nullable: true),
                    ToClubClubId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferLog", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_TransferLog_Clubs_FromClubClubId",
                        column: x => x.FromClubClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferLog_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferLog_Clubs_ToClubClubId",
                        column: x => x.ToClubClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferLog_FromClubClubId",
                table: "TransferLog",
                column: "FromClubClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLog_PlayerId",
                table: "TransferLog",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLog_ToClubClubId",
                table: "TransferLog",
                column: "ToClubClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferLog");
        }
    }
}
