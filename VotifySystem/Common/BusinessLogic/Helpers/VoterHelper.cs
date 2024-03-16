﻿namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper methods for Voter class 
/// </summary>
public static class VoterHelper
{
    /// <summary>
    /// Convert Vote method to friendly name 
    /// </summary>
    public static readonly Dictionary<string, string> VoteMethodFriendlyNames = new()
    {
        {"Online", "Online" },
        {"Postal", "Postal" },
        {"InPerson", "In Person" }
    };
}
