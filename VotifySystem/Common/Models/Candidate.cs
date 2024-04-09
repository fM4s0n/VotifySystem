using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.Models;

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
    public int ElectionPosition { get; set; } = 0;
    public ElectionVoteMechanism ElectionVoteMechanism { get; set; } = ElectionVoteMechanism.FPTP;
    public int VotesReceived { get; set; } = 0;

    /// <summary>
    /// Default Constructor for EF Core
    /// </summary>
    public Candidate() { }

    public Candidate(string firstName, string lastName, string constituencyId, string partyId, string electionId)
    {
        FirstName = firstName;
        LastName = lastName;
        ConstituencyId = constituencyId;
        PartyId = partyId;
        ElectionId = electionId;
        Id = Guid.NewGuid().ToString();
    }
}
