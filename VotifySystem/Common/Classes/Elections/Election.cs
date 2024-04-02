using System.ComponentModel.DataAnnotations.Schema;
using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Election class
/// </summary>
public abstract class Election
{
    public string ElectionId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ElectionAdministratorId { get; set; } = string.Empty;
    public Country Country { get; set; } = Country.UK;

    public ElectionStatus GetElectionStatus()
    {
        if (DateTime.Now < StartDate)
            return ElectionStatus.NotStarted;
        if (DateTime.Now > EndDate)
            return ElectionStatus.Completed;
        return ElectionStatus.InProgress;
    }

    public Election() { }
}

public enum ElectionStatus
{
    NotStarted,
    InProgress,
    Completed
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