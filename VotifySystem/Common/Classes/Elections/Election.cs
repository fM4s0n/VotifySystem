﻿using VotifySystem.Common.BusinessLogic.Helpers;

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
    public string ElectionAdministratorId { get; set; }
    public Country Country { get; set; } = Country.UK;

    public Election() { }
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