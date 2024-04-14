using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Interface for ElectionVoterService
/// </summary>
public interface IElectionVoterService
{
    /// <summary>
    /// Inserts a new ElectionVoter into the database
    /// </summary>
    /// <param name="electionVoter">ElectionVoter to be inserted</param>
    void InsertElectionVoter(ElectionVoter electionVoter);

    /// <summary>
    /// Updates an existing ElectionVoter in the database
    /// </summary>
    /// <param name="electionVoter">ElectionVoter to be updated</param>
    void UpdateElectionVoter(ElectionVoter electionVoter);  

    /// <summary>
    /// Deletes an existing ElectionVoter from the database
    /// </summary>
    /// <param name="electionVoter">ElectionVoter to be deleted</param>
    void DeleteElectionVoter(ElectionVoter electionVoter);

    /// <summary>
    /// Gets an ElectionVoter by its composite key
    /// </summary>
    /// <param name="electionId">electionId</param>
    /// <param name="voterId">VoterId</param>
    /// <returns>ElectionVoter instance if found, null if not</returns>
    ElectionVoter? GetElectionVoter(string electionId, string voterId);

    /// <summary>
    /// Gets all ElectionVoters for a given election
    /// </summary>
    /// <param name="electionId">electionId</param>
    /// <returns>List of all electionVoters registered in an election, null if none found</returns>
    List<ElectionVoter>? GetElectionVotersByElectionId(string electionId);

    /// <summary>
    /// Gets all ElectionVoters for a given voter
    /// </summary>
    /// <param name="voterId">Voter id</param>
    /// <returns>List of all ElectionVoters associated with a Voter</returns>
    List<ElectionVoter>? GetElectionVotersByVoterId(string voterId);
}
