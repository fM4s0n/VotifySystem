namespace VotifySystem.Common.Models.Votes;

/// <summary>
/// Preference class for a preferential vote.
/// Only to be used in the context of a preferential vote.
/// </summary>
public class PreferentialVotePreference
{
    // constructor for ef core
    public PreferentialVotePreference() { }

    public PreferentialVotePreference(string electionId, string voteId, int rank, string candidateId)
    {
        PreferenceId = Guid.NewGuid().ToString();
        ElectionId = electionId;
        VoteId = voteId;
        Rank = rank;
        CandidateId = candidateId;
    }

    public string PreferenceId { get; set; } = Guid.NewGuid().ToString();
    public string ElectionId { get; set; } = string.Empty;
    public string CandidateId { get; set; } = string.Empty;
    public string VoteId { get; set; } = string.Empty;
    public int Rank { get; set; }
}
