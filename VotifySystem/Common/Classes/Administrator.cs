namespace VotifySystem.Common.Classes;

/// <summary>
/// Administrator class
/// May not vote
/// </summary>
public class Administrator : User
{
    public Administrator() { }

    public Administrator(string firstName, string lastName) 
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
