namespace VotifySystem.Common.Classes;

/// <summary>
/// Parent class for all users
/// </summary>
public abstract class User : Person
{
    //Username is email for Voter and an Id for admin
    string Username = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserLevel UserLevel { get; set; }
}

public enum UserLevel
{
    None,
    Administrator,
    Voter
}