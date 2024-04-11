using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Interface for election bujilder
/// </summary>
public interface IElectionBuilder
{
    /// <summary>
    /// Sets the uniqueid of the election
    /// </summary>
    IElectionBuilder SetElectionId();

    /// <summary>
    /// Sets the description of the election
    /// </summary>
    IElectionBuilder SetDescription(string description);

    /// <summary>
    /// sets the start and end dates of the election
    /// </summary>
    IElectionBuilder SetDates(DateTime startDate, DateTime endDate);

    /// <summary>
    /// sets the id of the admin who created the election
    /// </summary>
    IElectionBuilder SetElectionAdministratorId(string userId);

    /// <summary>
    /// sets the country of the election
    /// </summary>
    IElectionBuilder SetCountry(Country country);

    /// <summary>
    /// Builds the election
    /// </summary>
    /// <returns>fully build Election object</returns>
    Election Build();
}
