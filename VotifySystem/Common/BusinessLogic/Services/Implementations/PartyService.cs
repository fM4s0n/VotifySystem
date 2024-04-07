using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;

public class PartyService : IPartyService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;

    //<inheritdoc/>
    public void InsertParty(Party party)
    {
        _dbService!.InsertEntity(party);
    }

    //<inheritdoc/>
    public void UpdateParty(Party party)
    {
        _dbService!.UpdateEntity(party);
    }

    //<inheritdoc/>
    public void DeleteParty(Party party)
    {
        _dbService!.DeleteEntity(party);
    }

    //<inheritdoc/>
    public List<Party>? GetAllParties()
    {
        return _dbService!.GetDatabaseContext().Parties.ToList() ?? null;
    }

    //<inheritdoc/>
    public List<Party>? GetPartiesByCountry(Country country)
    {
        return _dbService!.GetDatabaseContext().Parties.Where(p => p.Country == country).ToList() ?? null;
    }

    //<inheritdoc/>
    public Party? GetPartyById(string partyId)
    {
        return _dbService!.GetDatabaseContext().Parties.FirstOrDefault(p => p.PartyId == partyId) ?? null;
    }
}
