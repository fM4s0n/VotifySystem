﻿namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper methods for Voter class 
/// </summary>
public static class VoterHelper
{
    private static readonly Dictionary<string, string> VoteMethodFriendlyNames = new()
    {
        {"Online", "Online" },
        {"Postal", "Postal" },
        {"InPerson", "In Person" }
    };

    /// <summary>
    /// Convert Vote method to friendly name 
    /// </summary>
    public static string GetVoteMethodFriendlyName(string voteMethod)
    {
        return VoteMethodFriendlyNames[voteMethod];
    }

    /// <summary>
    /// enums for different methods of voting
    /// A voter may only have 1 method selected at any time but may change.
    /// </summary>
    public enum VoteMethod
    {
        Online,
        Postal,
        InPerson
    }
}
