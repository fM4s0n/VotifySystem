namespace VotifySystem.Classes;

/// <summary>
/// Parent class for all users
/// </summary>
internal abstract class User
{
    public string UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get { return $"{FirstName} {LastName}"; } }
    public string Password { get; set; } = string.Empty;
    private VoteMethod _selectedVoteMethod;
    public VoteMethod SelectedVoteMethod
    {
        get 
        { 
            return _selectedVoteMethod; 
        }      
        set 
        {
            if (this is Administrator && value != VoteMethod.NotAllowed)            
                throw new InvalidOperationException("Administrator may not have vote permissions");            
            else
                _selectedVoteMethod = value;
        }
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
    InPerson,
    NotAllowed
}
