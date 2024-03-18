using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotifySystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedPartyClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Party",
                table: "Candidate",
                newName: "PartyId");

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.PartyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.RenameColumn(
                name: "PartyId",
                table: "Candidate",
                newName: "Party");
        }
    }
}
