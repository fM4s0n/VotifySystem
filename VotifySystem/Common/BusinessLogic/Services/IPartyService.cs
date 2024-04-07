using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services;

internal interface IPartyService
{
    /// <summary>
    /// Add party
    /// </summary>
    /// <param name="party">Party</param>
    void InsertParty(Party party);

    /// <summary>
    /// Update party
    /// </summary>
    /// <param name="party">Party</param>
    void UpdateParty(Party party);

    /// <summary>
    /// Delete party
    /// </summary>
    /// <param name="party">Party</param>
    void DeleteParty(Party party);

    /// <summary>
    /// Get all parties
    /// </summary>
    /// <returns>List of parties</returns>
    List<Party>? GetAllParties();

    /// <summary>
    /// Get party by ID
    /// </summary>
    /// <param name="partyId">Party ID</param>
    /// <returns>Party</returns>
    Party? GetPartyById(string partyId);

    /// <summary>
    /// Gets a list of parties by country
    /// </summary>
    /// <param name="country">Country enum</param>
    /// <returns>List of parties in passed country, null if none found</returns>
    List<Party>? GetPartiesByCountry(Country country);
}
