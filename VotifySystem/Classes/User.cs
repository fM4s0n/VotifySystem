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
}
