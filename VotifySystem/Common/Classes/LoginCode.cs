namespace VotifySystem.Common.Classes;

/// <summary>
/// Class for unique login code.
/// Generated online to then be used once to login
/// </summary>
public class LoginCode
{
    public string Code { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public bool Used { get; set; } = false;
}
