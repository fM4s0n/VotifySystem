namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// FPTP vote class for an election.
/// </summary>
public class FPTPElectionVote : Vote
{
    private string _candidateId = string.Empty;

    // constructor for ef core
    public FPTPElectionVote() { }

    public FPTPElectionVote(string electionId)
    {
        VoteId = Guid.NewGuid().ToString();
        ElectionId = electionId;
        ElectionVoteMechanism = ElectionVoteMechanism.FPTP;
    }    

    /// <summary>
    /// Cast the vote for a candidate.
    /// </summary>
    /// <param name="candidateId">id of the candidate to be voted for</param>
    /// <returns>FPTPElectionVote object</returns>
    public FPTPElectionVote CastVote(string candidateId)
    {
        _candidateId = candidateId;
        return this;
    }

    /// <summary>
    /// Get the candidate id for the vote.
    /// </summary>
    /// <returns>string of the candidateId voted for</returns>
    public string GetCandidateId() => _candidateId;    
}
