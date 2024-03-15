using System.ComponentModel;

namespace VotifySystem.Common.Classes;

/// <summary>
/// Class for a voter
/// </summary>
public class Voter : User
{
    public VoteMethod SelectedVoteMethod;
    string Address { get; set; } = string.Empty;
    string ConstituencyId { get; set; } = string.Empty;
    DateTime DateOfBirth { get; set; } = DateTime.MinValue;

    public Voter(string firstName, string lastName, VoteMethod voteMethod, string address, string constituencyId)
    {
        FirstName = firstName;
        LastName = lastName;
        SelectedVoteMethod = voteMethod;
        Address = address;
        ConstituencyId = constituencyId;
    }     
}

/// <summary>
/// enums for different methods of voting
/// A voter may only have 1 method selected at any time but may change.
/// </summary>
public enum VoteMethod
{
    [Description("Online")]
    Online,
    [Description("Postal")]
    Postal,
    [Description("In Person")]
    InPerson
}

public Dict