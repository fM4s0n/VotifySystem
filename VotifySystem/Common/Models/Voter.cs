using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models;

/// <summary>
/// Class for a voter
/// </summary>
public class Voter : User
{
    public VoteMethod VoteMethod = VoteMethod.InPerson;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public Country Country { get; set; } = Country.UK;

    /// <summary>
    /// Default Constructor for EF core
    /// </summary>
    public Voter() { }

    public Voter(string firstName, string lastName, string username, VoteMethod voteMethod, string address, DateTime dateOfBirth, Country country)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        VoteMethod = voteMethod;
        Address = address;
        DateOfBirth = dateOfBirth;
        Id = Guid.NewGuid().ToString();
        UserLevel = UserLevel.Voter;
        Country = country;
    }
}


