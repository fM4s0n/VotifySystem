namespace VotifySystem.Classes;

/// <summary>
/// Class for a voter
/// </summary>
internal class Voter : User
{
    public Voter(string firstName, string lastName, VoteMethod voteMethod)
    {
        FirstName = firstName;
        LastName = lastName;
        SelectedVoteMethod = voteMethod;
    }
}

