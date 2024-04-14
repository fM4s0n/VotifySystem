using VotifySystem.Common.Models.Votes;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Service for FPTP votes
/// </summary>
public interface IFPTPElectionVoteService
{
    /// <summary>
    /// Insert a new FPTP vote into the database
    /// </summary>
    /// <param name="vote">Vote to be inserted</param>
    void InsertVote(FPTPElectionVote vote);

    /// <summary>
    /// Get all FPTP votes for an election
    /// </summary>
    /// <param name="electionId">ElectionId</param>
    /// <returns>List of votes if found, null if not</returns>
    List<FPTPElectionVote>? GetFPTPVotesByElectionId(string electionId);

    /// <summary>
    /// Gets all FPTP votes for a candidate
    /// </summary>
    /// <param name="candidateId">Candidate Id</param>
    /// <returns>List of votes for a candidate, null if none found</returns>
    List<FPTPElectionVote>? GetFPTPVotesByCandidateId(string candidateId);

    /// <summary>
    /// Gets the number of votes for a candidate
    /// </summary>
    /// <param name="candidateId">Id of the candidate</param>
    /// <returns>int of the number of total votes received by the candidate</returns>
    int GetFPTPVotesCountByCandidateId(string candidateId);
}
