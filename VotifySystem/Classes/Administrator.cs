namespace VotifySystem.Classes;

/// <summary>
/// Administrator class
/// May not vote
/// </summary>
public class Administrator : User
{
    public Administrator(string firstName, string lastName) 
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
