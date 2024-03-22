namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Associative class to solve many to many relationship of Election and Candidate classes
/// </summary>
public class ElectionCandidate
{
    public string CandidateId { get; set; } = string.Empty;
    public string ElectionId { get; set; } = string.Empty;
    public int VotesReceived { get; private set; } = 0;

    /// <summary>
    /// Default Constructor for EF Core
    /// </summary>
    public ElectionCandidate() { }

    public ElectionCandidate(string candidateId, string electionId)
    {
        CandidateId = candidateId;
        ElectionId = electionId;
    }

    /// <summary>
    /// Add or remove votes for an electionCandidate
    /// </summary>
    /// <param name="votesReceived">Votes to add. Can be positive or negative if required</param>
    public void AddVotes(int votesReceived)
    {
        VotesReceived += votesReceived;
    }
}
