namespace VotifySystem.Classes;

/// <summary>
/// Class for a voter
/// </summary>
internal class Voter : User
{
    public VoteMethod VoterType { get; set; }

    public Voter(string firstName, string lastName) 
    { 
        FirstName = firstName;
        LastName = lastName;
    }
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
