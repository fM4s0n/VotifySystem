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
    /// Gets all preferences associated with a vote.
    /// </summary>
    /// <param name="voteId"></param>
    /// <returns>List of Preference objects associated with a vote</returns>
    List<PreferentialVotePreference>? GetPreferencesByVoteId(string voteId);

    List<PreferentialVotePreference>? GetPreferencesByElectionId(string electionId);
}
