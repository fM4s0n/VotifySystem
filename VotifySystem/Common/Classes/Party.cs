using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Classes;

/// <summary>
/// Party class
/// Party is linked to a country
/// </summary>
public  class Party
{    
    /// <summary>
    /// Empty constructor for EF Core
    /// </summary>
    public Party() { }

    /// <summary>
    /// Constructor to create a new party
    /// </summary>
    /// <param name="name">Name of the party</param>
    /// <param name="country">Associated country</param>
    public Party(string name, Country country) 
    { 
        Name = name;
        Country = country;
        PartyId = Guid.NewGuid().ToString();
    }

    public string PartyId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Country Country { get; set; }
}
