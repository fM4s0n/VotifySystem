namespace VotifySystem.Common.Classes;

/// <summary>
/// Associative class to solve many to many relationship of Election and Candidate classes
/// </summary>
public class ElectionCandidate
{
    public string CandidateId { get; set; } = string.Empty;
    public string ElectionId { get; set; } = string.Empty;
    public int VotesReceived { get; set; } = 0;
}
