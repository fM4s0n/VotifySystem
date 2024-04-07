namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Class to represent a single voter in an election
/// solves the many to many relationship between voter and election
/// this will also be used to ensue a voter can only vote once in an election
/// only store that they have voted and not the vote itself
/// </summary>
public class ElectionVoter
{
    public string ElectionId { get; set; } = string.Empty;
    public string VoterId { get; set; } = string.Empty;
    public string ConstituencyId { get; set; } = string.Empty;
    public bool HasVoted { get; set; } = false;

    public ElectionVoter() { }

    public ElectionVoter(string electionId, string voterId, string constituencyId)
    {
        ElectionId = electionId;
        VoterId = voterId;
        ConstituencyId = constituencyId;
        HasVoted = false;
    }
}
