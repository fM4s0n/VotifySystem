using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;

internal class PreferentialVoteService : IPreferentialVoteService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;  

    //<inheritdoc/>
    public void InsertVote(PreferentialElectionVote vote)
    {
        _dbService!.InsertEntity(vote);
    }

    //<inheritdoc/>
    public List<PreferentialVotePreference>? GetPreferencesByElectionId(string electionId)
    {
        return _dbService!.GetDatabaseContext().PreferentialVotePreferences.Where(p => p.ElectionId == electionId).ToList() ?? null;
    }

    //<inheritdoc/>
    public List<PreferentialVotePreference>? GetPreferencesByVoteId(string voteId)
    {
        return _dbService!.GetDatabaseContext().PreferentialVotePreferences.Where(p => p.VoteId == voteId).ToList() ?? null;
    }
}
