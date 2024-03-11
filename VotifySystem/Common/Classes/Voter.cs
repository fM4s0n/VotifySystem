namespace VotifySystem.Common.Classes;

/// <summary>
/// Class for a voter
/// </summary>
public class Voter : User
{
    public VoteMethod SelectedVoteMethod;

    public Voter(string firstName, string lastName, VoteMethod voteMethod, string address, string constituency)
    {
        FirstName = firstName;
        LastName = lastName;
        SelectedVoteMethod = voteMethod;
        Address = address;
        Constituency = constituency;
    }     

    string Address { get; set; } = string.Empty;
    string Constituency {  get; set; } = string.Empty;
}

/// <summary>
/// enums for different methods of voting
/// A voter may only have 1 method selected at any time but may change.
/// </summary>
public enum VoteMethod
{
    Online,
    Postal,
    InPerson,
    NotAllowed
}