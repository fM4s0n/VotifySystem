namespace VotifySystem.Common.Classes;

/// <summary>
/// Candidate Class
/// Does not need to login as if they want to vote, they should be a voter.
/// Administrator will create the election with relevant candidates
/// </summary>
public class Candidate : Person
{
    public string ConstituencyId { get; set; } = string.Empty;
    public string Party { get; set; } = string.Empty;

    public Candidate() { }

    public Candidate(string constituencyId, string party)
    {
        ConstituencyId = constituencyId;
        Party = party;
    }
}
