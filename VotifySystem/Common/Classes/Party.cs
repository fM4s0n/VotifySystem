using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Classes;

/// <summary>
/// 
/// </summary>
public  class Party
{    
    public Party() { }

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
