namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Abstract class for a vote in an election.
/// </summary>
public abstract class Vote(string electionId, ElectionVoteMechanism electionVoteMechanism)
{
    /// <summary>
    /// Unique id for the vote.
    /// </summary>
    public string VoteId { get; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Id of the election which the vote is cast in.
    /// </summary>
    public string ElectionId { get; } = electionId;

    /// <summary>
    /// Vote mechanism of the Vote is for
    /// </summary>
    public ElectionVoteMechanism ElectionVoteMechanism { get; } = electionVoteMechanism;

    /// <summary>
    /// Cast the vote for a candidate.
    /// </summary>
    /// <param name="candidateId">Casts the vote</param>
    public abstract Vote CastVote(string candidateId);

}
