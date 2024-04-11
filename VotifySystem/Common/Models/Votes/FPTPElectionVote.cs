using VotifySystem.Common.Models.Elections;

namespace VotifySystem.Common.Models.Votes;

/// <summary>
/// FPTP vote class for an election.
/// </summary>
public class FPTPElectionVote : Vote
{
    public string CandidateId { get; set; } = string.Empty;

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
        CandidateId = candidateId;
        return this;
    }
}
