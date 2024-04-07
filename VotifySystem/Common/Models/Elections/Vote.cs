namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Abstract class for a vote in an election.
/// </summary>
public abstract class Vote
{
    /// <summary>
    /// Unique id for the vote.
    /// </summary>
    public string VoteId { get; set; } = string.Empty;

    /// <summary>
    /// Id of the election which the vote is cast in.
    /// </summary>
    public string ElectionId { get; set; } = string.Empty;

    /// <summary>
    /// Vote mechanism of the Vote is for
    /// </summary>
    public ElectionVoteMechanism ElectionVoteMechanism { get; set; }

    public Vote() { } 
}
