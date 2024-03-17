﻿namespace VotifySystem.Common.Classes;

/// <summary>
/// Constituency class
/// Not many to many as each election must create new list of constituencies each time.
/// This is because boundaries can change between elections so must be new each time
/// </summary>
public class Constituency
{
    public string ConstituencyId { get; set; } = string.Empty;
    public string ConstituencyName { get; set; } = string.Empty;
    public string ElectionId { get; set; } = string.Empty;

    public Constituency()
    {
    }

    public Constituency (string constituencyId, string constituencyName, string electionId)
    {
        ConstituencyId = constituencyId;
        ConstituencyName = constituencyName;
        ElectionId = electionId;
    }
}
