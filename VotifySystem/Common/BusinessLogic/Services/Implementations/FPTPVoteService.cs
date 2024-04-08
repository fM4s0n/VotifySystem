using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.BusinessLogic.Services.Implementations;
public class FPTPVoteService : IFPTPVoteService
{
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;

    //<inheritdoc/>
    public void InsertVote(FPTPElectionVote vote)
    {
        _dbService!.InsertEntity(vote);
    }

    //<inheritdoc/>
    public void UpdateVote(FPTPElectionVote vote)
    {
        _dbService!.UpdateEntity(vote);
    }

    //<inheritdoc/>
    public void DeleteVote(FPTPElectionVote vote)
    {
        _dbService!.DeleteEntity(vote);
    }

    //<inheritdoc/>
    public FPTPElectionVote? GetFPTPVoteById(string voteId)
    {
        return _dbService!.GetDatabaseContext().Votes.FirstOrDefault(v => v.VoteId == voteId) as FPTPElectionVote ?? null;
    }

    //<inheritdoc/>
    public List<FPTPElectionVote>? GetFPTPVotesByCandidateId(string candidateId)
    {
        List<FPTPElectionVote>? votes = _dbService!.GetDatabaseContext().Votes
                        .Where(v => v as FPTPElectionVote != null && ((FPTPElectionVote)v).CandidateId == candidateId)
                        .Cast<FPTPElectionVote>()
                        .ToList();

        return votes.Count > 0 ? votes : null;
    }

    //<inheritdoc/>
    public List<FPTPElectionVote>? GetFPTPVotesByElectionId(string electionId)
    {
        List<FPTPElectionVote>? votes = _dbService!.GetDatabaseContext().Votes
                        .Where(v => v as FPTPElectionVote != null && v.ElectionId == electionId)
                        .Cast<FPTPElectionVote>()
                        .ToList();

        return votes.Count > 0 ? votes : null;
    }

    //<inheritdoc/>
    public int GetFPTPVotesCountByCandidateId(string candidateId)
    {
        int votes = 0;
        List<FPTPElectionVote>? candidateVotes = GetFPTPVotesByCandidateId(candidateId);

        if (candidateVotes != null)        
            votes = candidateVotes.Count;
        
        return votes;
    }
}
