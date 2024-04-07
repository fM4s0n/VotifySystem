using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;

internal class ConstituencyService : IConstituencyService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;

    //<inheritdoc/>
    public void InsertConstituency(Constituency constituency)
    {
        _dbService!.InsertEntity(constituency);
    }

    //<inheritdoc/>
    public void UpdateConstituency(Constituency constituency)
    {
        _dbService!.UpdateEntity(constituency);
    }

    //<inheritdoc/>
    public void DeleteConstituency(Constituency constituency)
    {
        _dbService!.DeleteEntity(constituency);
    }

    //<inheritdoc/>
    public List<Constituency>? GetAllConstituencies()
    {
        return _dbService!.GetDatabaseContext().Constituencies.ToList() ?? null;
    }

    //<inheritdoc/>
    public List<Constituency>? GetConstituenciesByCountry(Country country)
    {
        return _dbService!.GetDatabaseContext().Constituencies.Where(c => c.Country == country).ToList() ?? null;
    }

    //<inheritdoc/>
    public List<Constituency>? GetConstituenciesByElectionId(string electionId)
    {
        return _dbService!.GetDatabaseContext().Constituencies.Where(c => c.ElectionId == electionId).ToList() ?? null;
    }

    //<inheritdoc/>
    public Constituency? GetConstituencyByConstituencyId(string constituencyId)
    {
        return _dbService!.GetDatabaseContext().Constituencies.FirstOrDefault(c => c.ConstituencyId == constituencyId) ?? null;
    }
}
