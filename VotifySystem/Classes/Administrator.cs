namespace VotifySystem.Classes;

/// <summary>
/// Admisitrator class
/// May not vote
/// </summary>
internal class Administrator : User
{
    public Administrator(string firstName, string lastName) 
    {
        FirstName = firstName;
        LastName = lastName;
        SelectedVoteMethod = VoteMethod.NotAllowed;
    }
}
