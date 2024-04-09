using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;
public class CandidateService(IDbService? dbService = null, IFPTPElectionVoteService? voteService = null) : ICandidateService
{
    private readonly IDbService? _dbService = dbService ?? Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
    private readonly IFPTPElectionVoteService? _voteService = voteService ?? Program.ServiceProvider!.GetService(typeof(IFPTPElectionVoteService)) as IFPTPElectionVoteService;

    //<inheritdoc/>
    public void InsertCandidate(Candidate candidate)
    {
        _dbService!.InsertEntity(candidate);
    }

    //<inheritdoc/>
    public void UpdateCandidate(Candidate candidate)
    {
        _dbService!.UpdateEntity(candidate);
    }

    //<inheritdoc/>
    public void DeleteCandidate(Candidate candidate)
    {
        _dbService!.DeleteEntity(candidate);
    }

    //<inheritdoc/>
    public List<Candidate>? GetAllCandidates()
    {
        var candidates = _dbService!.GetDatabaseContext().Candidates.ToList() ?? null;
        
        return candidates != null ? UpdateVotesReceived(candidates) : null;
    }

    //<inheritdoc/>
    public List<Candidate>? GetCandidatesByElectionId(string electionId)
    {
        var candidates = _dbService!.GetDatabaseContext().Candidates.Where(c => c.ElectionId == electionId).ToList() ?? null;

        return candidates != null ? UpdateVotesReceived(candidates) : null;
    }

    //<inheritdoc/>
    public List<Candidate>? GetCandidatesByPartyId(string partyId)
    {
        var candidates = _dbService!.GetDatabaseContext().Candidates.Where(c => c.PartyId == partyId).ToList() ?? null;
         
        return candidates != null ? UpdateVotesReceived(candidates) : null;
    }

    /// <summary>
    /// Updates the votes received for each candidate in the list.
    /// </summary>
    /// <param name="candidates">Candidates to be updated</param>
    /// <returns>List of candidates with the votes received property populated</returns>
    private List<Candidate> UpdateVotesReceived(List<Candidate> candidates)
    {
        foreach (Candidate candidate in candidates)        
            candidate.VotesReceived = _voteService!.GetFPTPVotesCountByCandidateId(candidate.Id);        

        return candidates;
    }
}
