namespace VotifySystem.Common.Classes;

/// <summary>
/// Parent class for all users
/// </summary>
public abstract class User : Person
{
    // Username is email for Voter and an Id for admin
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserLevel UserLevel { get; set; } = UserLevel.None;

    public User() { }
}

/// <summary>
/// User Level enum to determine what type of user they are.
/// </summary>
public enum UserLevel
{
    None,
    Administrator,
    Voter
}