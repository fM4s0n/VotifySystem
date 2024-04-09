using System.ComponentModel.DataAnnotations.Schema;
using VotifySystem.Common.BusinessLogic.Services;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Preferential vote class for an election.
/// </summary>
/// <param name="electionId">ElectionId the vote is associated with</param>
public class PreferentialElectionVote : Vote
{
    [NotMapped]
    private List<PreferentialVotePreference> _preferences = [];

    private readonly IPreferentialVoteService? _preferentialVoteService = Program.ServiceProvider!.GetService(typeof(IPreferentialVoteService)) as IPreferentialVoteService;

    // constructor for ef core
    public PreferentialElectionVote() { }

    public PreferentialElectionVote(string electionId) 
    {
        VoteId = Guid.NewGuid().ToString();
        ElectionId = electionId; 
        ElectionVoteMechanism = ElectionVoteMechanism.Preferential;
    }

    /// <summary>
    /// Creates a preferential vote with a list of candidates.
    /// Candidates are ranked in the order they are passed in.
    /// </summary>
    /// <param name="candidateIds"></param>
    /// <returns>PreferentialElectionVote object with all candidates ranked</returns>
    public PreferentialElectionVote CastVote(List<string> candidateIds)
    {
        int nextRank = _preferences.Count + 1;

        foreach (string candidate in candidateIds)
        {
            PreferentialVotePreference? preference = new(ElectionId, VoteId, nextRank, candidate);
            _preferences.Add(preference);
            nextRank++;
        }

        return this;
    }

    public PreferentialVotePreference? GetFirstPreference()
    {
        return _preferences.FirstOrDefault() ?? null;
    }

    public PreferentialVotePreference? GetPreferenceByRank(int rank)
    {
        return _preferences.FirstOrDefault(p => p.Rank == rank) ?? null;
    }

    public PreferentialVotePreference? GetPreferenceByCandidateId(string candidateId)
    {
        return _preferences.FirstOrDefault(p => p.CandidateId == candidateId) ?? null;
    }

    public void LoadPreferences()
    {
        _preferences = _preferentialVoteService!.GetPreferencesByVoteId(VoteId) ?? [];
    }
}
