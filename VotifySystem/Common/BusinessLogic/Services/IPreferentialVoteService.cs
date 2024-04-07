using VotifySystem.Common.Models.Elections;

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
    /// Updates a vote in the database.
    /// </summary>
    /// <param name="vote">Vote to be updated</param>
    void UpdateVote(PreferentialElectionVote vote);

    /// <summary>
    /// Deletes a vote from the database.
    /// </summary>
    /// <param name="vote">Vote to be deleted</param>
    void DeleteVote(PreferentialElectionVote vote);

    /// <summary>
    /// Gets a vote by its voteId.
    /// </summary>
    /// <param name="voteId">voteId</param>
    /// <returns>Vote instance if found, null if not</returns>
    PreferentialElectionVote? GetVoteByVoteId(string voteId);

    /// <summary>
    /// Gets all preferences associated with a vote.
    /// </summary>
    /// <param name="voteId"></param>
    /// <returns>List of Preference objects associated with a vote</returns>
    List<PreferentialVotePreference>? GetPreferencesByVoteId(string voteId);

    List<PreferentialVotePreference>? GetPreferencesByElectionId(string electionId);
}
