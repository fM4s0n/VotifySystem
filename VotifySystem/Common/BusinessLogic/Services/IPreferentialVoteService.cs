
using VotifySystem.Common.Models.Votes;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Service for preferential votes. handles all data operations for preferential votes.
/// </summary>
public interface IPreferentialVoteService
{
    /// <summary>
    /// Inserts a vote into the database.
    /// </summary>
    /// <param name="vote">Vote to be inserted</param>
    void InsertVote(PreferentialElectionVote vote);

    /// <summary>
    /// Inserts a preference into the database.
    /// </summary>
    /// <param name="preference">Prefrecne to be instyerted into the database</param>
    void InsertPreference(PreferentialVotePreference preference);

    /// <summary>
    /// Inserts a list of preferences into the database.
    /// </summary>
    /// <param name="preferences">List of preferences to be insterted</param>
    void InsertPreferences(List<PreferentialVotePreference> preferences);

    /// <summary>
    /// Gets all preferences associated with a vote.
    /// </summary>
    /// <param name="voteId"></param>
    /// <returns>List of Preference objects associated with a vote</returns>
    List<PreferentialVotePreference>? GetPreferencesByVoteId(string voteId);

    /// <summary>
    /// Gets all preferences associated with an election.
    /// </summary>
    /// <param name="electionId">ElectionId</param>
    /// <returns>List of all preference associated with an election</returns>
    List<PreferentialVotePreference>? GetPreferencesByElectionId(string electionId);
}
