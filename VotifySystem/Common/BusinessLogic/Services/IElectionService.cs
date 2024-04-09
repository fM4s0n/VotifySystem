using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Service for managing elections
/// </summary>
public interface IElectionService
{
    /// <summary>
    /// Inserts a new election into the database
    /// </summary>
    /// <param name="election"></param>
    void InsertElection(Election election);

    /// <summary>
    /// deletes an election from the database
    /// </summary>
    /// <param name="election"></param>
    void DeleteElection(Election election);

    /// <summary>
    /// Updates an election in the database
    /// </summary>
    /// <param name="election"></param>
    void UpdateElection(Election election);

    /// <summary>
    /// gets all elections
    /// </summary>
    /// <returns></returns>
    List<Election>? GetAllElections();

    /// <summary>
    /// Gets all elections for a specific country
    /// </summary>
    /// <param name="country">Country enum</param>
    /// <returns>List of elections filtered by country</returns>
    List<Election>? GetElectionsByCountry(Country country);
}
