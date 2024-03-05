namespace VotifySystem.Classes;

/// <summary>
/// Class for a voter
/// </summary>
internal class Voter : User
{
    public VoteMethod SelectedVoteMethod;

    public Voter(string firstName, string lastName, VoteMethod voteMethod)
    {
        FirstName = firstName;
        LastName = lastName;
        SelectedVoteMethod = voteMethod;
    }     
}

/// <summary>
/// enums for different methods of voting
/// A voter may only have 1 method selected at any time but may change.
/// </summary>
internal enum VoteMethod
{
    Online,
    Postal,
    InPerson,
    NotAllowed
}