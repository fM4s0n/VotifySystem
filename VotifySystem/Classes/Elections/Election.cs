namespace VotifySystem.Classes.Elections;

/// <summary>
/// Election class
/// </summary>
public abstract class Election
{
    public string ElectionId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public List<Candidate> Candidates { get; set; } = [];
    public ElectionVoteMechanism VoteMechanism { get; set; }
}

/// <summary>
/// Method which election uses to vote
/// </summary>
public enum ElectionVoteMechanism
{
    //First Past The Post
    FPTP,
    //Single Transferrable Vote
    STV
}