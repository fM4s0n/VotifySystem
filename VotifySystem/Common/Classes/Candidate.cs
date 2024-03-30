namespace VotifySystem.Common.Classes;

/// <summary>
/// Candidate Class
/// Does not need to login as if they want to vote, they should be a voter.
/// Administrator will create the election with relevant candidates
/// </summary>
public class Candidate : Person
{
    public string ConstituencyId { get; set; } = string.Empty;
    public string PartyId { get; set; } = string.Empty;
    public string ElectionId { get; set; } = string.Empty;
    public int VotesReceived { get; private set; } = 0;

    /// <summary>
    /// Default Constructor for EF Core
    /// </summary>
    public Candidate() { }

    public Candidate(string firstName, string lastName, string constituencyId, string partyId)
    {
        FirstName = firstName;
        LastName = lastName;
        ConstituencyId = constituencyId;
        PartyId = partyId;
        Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Add or remove votes for an electionCandidate
    /// TODO: Refactor to use a Vote object and vote table to allow for multiple votes concurrently
    /// </summary>
    /// <param name="votesReceived">Votes to add. Can be positive or negative if required</param>
    public void AddVotes(int votesReceived)
    {
        VotesReceived += votesReceived;
    }
}
