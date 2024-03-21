using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotifySystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountryToVoter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Voter",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Voter");
        }
    }
}
