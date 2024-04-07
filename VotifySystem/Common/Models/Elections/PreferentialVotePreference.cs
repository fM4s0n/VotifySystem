namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Preference class for a preferential vote.
/// Only to be used in the context of a preferential vote.
/// </summary>
public class PreferentialVotePreference(string electionId, string voteId, int rank, string candidateId)
{
    public string ElectionId { get; set; } = electionId;
    public string PreferenceId { get; set; } = Guid.NewGuid().ToString();
    public string CandidateId { get; set; } = candidateId;
    public string VoteId { get; set; } = voteId;
    public int Rank { get; set; } = rank;
}
