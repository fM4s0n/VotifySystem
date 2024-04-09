using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Constituency Service
/// </summary>
internal interface IConstituencyService
{
    /// <summary>
    /// Inserts a new constituency into the database.
    /// </summary>
    /// <param name="constituency">Constituency to be inserted</param>
    void InsertConstituency(Constituency constituency);

    /// <summary>
    /// Updates a constituency in the database.
    /// </summary>
    /// <param name="constituency">Constituency to be updated</param>
    void UpdateConstituency(Constituency constituency);

    /// <summary>
    /// Deletes a constituency from the database.
    /// </summary>
    /// <param name="constituency">Constituency to be deleted</param>
    void DeleteConstituency(Constituency constituency);

    /// <summary>
    /// Gets all constituencies from the database.
    /// </summary>
    /// <returns>List of all constituencies, null if none found</returns>
    List<Constituency>? GetAllConstituencies();

    /// <summary>
    /// Gets all constituencies by country.
    /// </summary>
    /// <param name="country">Country enum</param>
    /// <returns>List of all constituencies for that country, null if none</returns>
    List<Constituency>? GetConstituenciesByCountry(Country country);

    /// <summary>
    /// List of constituencies by election id
    /// </summary>
    /// <param name="electionId">id of the election</param>
    /// <returns>List of all constituencies with passed electionId, null if none found</returns>
    List<Constituency>? GetConstituenciesByElectionId(string electionId);
}
