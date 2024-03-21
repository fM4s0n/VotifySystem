namespace VotifySystem.Common.Classes;

/// <summary>
/// Class for a voter
/// </summary>
public class Voter : User
{
    public VoteMethod VoteMethod = VoteMethod.InPerson;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Default Constructor for EF core
    /// </summary>
    public Voter()
    {
    }

    public Voter(string firstName, string lastName, string username, VoteMethod voteMethod, string address, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        VoteMethod = voteMethod;
        Address = address;
        DateOfBirth = dateOfBirth;
        Id = Guid.NewGuid().ToString();
        UserLevel = UserLevel.Voter;
    }

    public static readonly Dictionary<string, string> VoteMethodFriendlyNames = new()
    {
        {"Online", "Online" },
        {"Postal", "Postal" },
        {"InPerson", "In Person" }
    };
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
