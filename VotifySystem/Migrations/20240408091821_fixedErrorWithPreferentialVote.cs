using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotifySystem.Migrations
{
    /// <inheritdoc />
    public partial class fixedErrorWithPreferentialVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VotesReceived",
                table: "Candidate",
                newName: "ElectionVoteMechanism");

            migrationBuilder.AddColumn<string>(
                name: "CandidateId",
                table: "Vote",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PreferentialVotePreference",
                columns: table => new
                {
                    PreferenceId = table.Column<string>(type: "TEXT", nullable: false),
                    ElectionId = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateId = table.Column<string>(type: "TEXT", nullable: false),
                    VoteId = table.Column<string>(type: "TEXT", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferentialVotePreference", x => x.PreferenceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferentialVotePreference");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Vote");

            migrationBuilder.RenameColumn(
                name: "ElectionVoteMechanism",
                table: "Candidate",
                newName: "VotesReceived");
        }
    }
}
