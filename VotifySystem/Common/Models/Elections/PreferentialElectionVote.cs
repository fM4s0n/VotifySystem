namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Preferential vote class for an election.
/// </summary>
/// <param name="electionId">ElectionId the vote is associated with</param>
public class PreferentialElectionVote(string electionId) : Vote(electionId, ElectionVoteMechanism.STV)
{
    private readonly List<string> _preferences = [];

    public PreferentialElectionVote AddPreference(string candidateId)
    {
        _preferences.Add(candidateId);
        return this;
    }

    public override PreferentialElectionVote CastVote(string candidate)
    {
        if (_preferences.Contains(candidate))
        {
            Console.WriteLine($"Vote {VoteId} cast for {candidate} in Preferential system of Election {ElectionId}");
        }
        else
        {
            Console.WriteLine($"Invalid vote {VoteId} cast for {candidate} in Preferential system of Election {ElectionId}");
        }

        return this;
    }

    public string GetFirstPreference()
    {
        return _preferences.FirstOrDefault();
    }
}
