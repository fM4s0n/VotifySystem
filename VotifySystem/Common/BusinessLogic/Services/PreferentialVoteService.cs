using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.BusinessLogic.Services;

internal class PreferentialVoteService : IPreferentialVoteService
{
    //<inheritdoc/>
    public void DeleteVote(PreferentialElectionVote vote)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public List<PreferentialVotePreference>? GetPreferencesByElectionId(string electionId)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public List<PreferentialVotePreference>? GetPreferencesByVoteId(string voteId)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public PreferentialElectionVote? GetVoteByVoteId(string voteId)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public void InsertVote(PreferentialElectionVote vote)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public void UpdateVote(PreferentialElectionVote vote)
    {
        throw new NotImplementedException();
    }
}
