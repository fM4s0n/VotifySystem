namespace VotifySystem.Common.Classes;

/// <summary>
/// Administrator class
/// May not vote
/// </summary>
public class Administrator : User
{
    /// <summary>
    /// Default Constructor for EF Core
    /// </summary>
    public Administrator() { }

    public Administrator(string firstName, string lastName, string username) 
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        UserLevel = UserLevel.Administrator;
        Id = Guid.NewGuid().ToString();
    }
}
