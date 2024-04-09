using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;
internal class CandidateService : ICandidateService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;

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
        return _dbService!.GetDatabaseContext().Candidates.ToList() ?? null;
    }

    //<inheritdoc/>
    public List<Candidate>? GetCandidatesByElectionId(string electionId)
    {
        return _dbService!.GetDatabaseContext().Candidates.Where(c => c.ElectionId == electionId).ToList() ?? null;
    }

    //<inheritdoc/>
    public List<Candidate>? GetCandidatesByPartyId(string partyId)
    {
        return _dbService!.GetDatabaseContext().Candidates.Where(c => c.PartyId == partyId).ToList() ?? null;
    }
}
