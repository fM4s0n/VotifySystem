using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services;

public interface ICandidateService
{
    /// <summary>
    /// Inserts a candidate into the database.
    /// </summary>
    /// <param name="candidate">The candidate to insert.</param>
    void InsertCandidate(Candidate candidate);

    /// <summary>
    /// Updates a candidate in the database.
    /// </summary>
    /// <param name="candidate">The candidate to update.</param>
    void UpdateCandidate(Candidate candidate);

    /// <summary>
    /// Deletes a candidate from the database.
    /// </summary>
    /// <param name="candidate">The candidate to delete.</param>
    void DeleteCandidate(Candidate candidate);

    /// <summary>
    /// Gets all candidates from the database.
    /// </summary>
    /// <returns>A list of all candidates, null if none found</returns>
    List<Candidate>? GetAllCandidates();

    /// <summary>
    /// Gets a candidate by their candidate ID.
    /// </summary>
    /// <param name="id">The candidate ID to search for.</param>
    /// <returns>The candidate with the specified ID, null if not found</returns>
    Candidate? GetCandidateByCandidateId(string id);

    /// <summary>
    /// Gets all candidates in a specific election.
    /// </summary>
    /// <param name="electionId"></param>
    /// <returns>List of candidates if any found, null if not</returns>
    List<Candidate>? GetCandidatesByElectionId(string electionId);

    /// <summary>
    /// gets a list of candidates by party id
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns>List of candidates matching the party id, returns null if none found</returns>
    List<Candidate>? GetCandidatesByPartyId(string partyId);
}
