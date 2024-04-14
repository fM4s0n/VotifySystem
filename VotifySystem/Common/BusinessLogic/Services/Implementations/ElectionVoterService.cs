using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;

public class ElectionVoterService : IElectionVoterService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;

    //<inheritdoc/>
    public void InsertElectionVoter(ElectionVoter electionVoter)
    {
        _dbService!.InsertEntity(electionVoter);
    }

    //<inheritdoc/>
    public void UpdateElectionVoter(ElectionVoter electionVoter)
    {
        _dbService!.UpdateEntity(electionVoter);
    }

    //<inheritdoc/>
    public void DeleteElectionVoter(ElectionVoter electionVoter)
    {
        _dbService!.DeleteEntity(electionVoter);
    }

    //<inheritdoc/>
    public ElectionVoter? GetElectionVoter(string electionId, string voterId)
    {
       return _dbService!.GetDatabaseContext().ElectionVoters
            .Where(ev => ev.ElectionId == electionId && ev.VoterId == voterId)
            .FirstOrDefault() ?? null;
    }

    //<inheritdoc/>
    public List<ElectionVoter>? GetElectionVotersByElectionId(string electionId)
    {
        return _dbService!.GetDatabaseContext().ElectionVoters
            .Where(ev => ev.ElectionId == electionId)
            .ToList() ?? null;
    }

    //<inheritdoc/>
    public List<ElectionVoter>? GetElectionVotersByVoterId(string voterId)
    {
        return _dbService!.GetDatabaseContext().ElectionVoters
            .Where(ev => ev.VoterId == voterId)
            .ToList() ?? null;
    }
}
