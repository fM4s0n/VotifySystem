namespace VotifySystem.Common.Classes;

/// <summary>
/// Constituency class
/// Not many to many as each election must create new list of constituencies each time.
/// This is because boundaries can change between elections so must be new each time
/// </summary>
public class Constituency
{
    public string ConstituencyId { get; set; } = string.Empty;
    public string ConstituencyName { get; set; } = string.Empty;
    public string ElectionId { get; set; } = string.Empty;

    /// <summary>
    /// Default Constructor for EF Core
    /// </summary>
    public Constituency() { }

    public Constituency (string constituencyName, string electionId)
    {
        ConstituencyId = Guid.NewGuid ().ToString();
        ConstituencyName = constituencyName;
        ElectionId = electionId;
    }
}
