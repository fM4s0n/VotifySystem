namespace VotifySystem.Classes;

/// <summary>
/// Parent class for all users
/// </summary>
public abstract class User : Person
{
    public string UserId { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
