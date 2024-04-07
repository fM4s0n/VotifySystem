namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// FPTP vote class for an election.
/// </summary>
/// /// <param name="electionId">ElectionId the vote is associated with</param>
public class FPTPElectionVote(string electionId) : Vote(electionId, ElectionVoteMechanism.FPTP)
{
    private string _candidateId = string.Empty;

    /// <summary>
    /// Cast the vote for a candidate.
    /// </summary>
    /// <param name="candidateId">id of the candidate to be voted for</param>
    /// <returns>FPTPElectionVote object</returns>
    public override FPTPElectionVote CastVote(string candidateId)
    {
        _candidateId = candidateId;
        return this;
    }

    /// <summary>
    /// Get the candidate id for the vote.
    /// </summary>
    /// <returns>string of the candidateId voted for</returns>
    public string GetCandidateId()
    {
        return _candidateId;
    }
}
