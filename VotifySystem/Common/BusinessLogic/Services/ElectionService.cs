using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Common.BusinessLogic.Services;

internal class ElectionService() : IElectionService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;

    //<inheritdoc/>
    public void DeleteElection(Election election)
    {
        _dbService!.DeleteEntity(election);
    }

    //<inheritdoc/>
    public List<Election>? GetAllElections()
    {
        return _dbService!.GetDatabaseContext().Elections.ToList() ?? null;
    }

    //<inheritdoc/>
    public Election? GetElectionByElectionId(string id)
    {
        return _dbService!.GetDatabaseContext().Elections.FirstOrDefault(e => e.ElectionId == id) ?? null;
    }

    //<inheritdoc/>
    public List<Election>? GetElectionsByCountry(Country country)
    {
        return _dbService!.GetDatabaseContext().Elections.Where(e => e.Country == country).ToList() ?? null;
    }

    //<inheritdoc/>
    public void InsertElection(Election election)
    {
        _dbService!.InsertEntity(election);
    }

    //<inheritdoc/>
    public void UpdateElection(Election election)
    {
        _dbService!.UpdateEntity(election);
    }
}
