using System.ComponentModel.DataAnnotations.Schema;

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
    public DateTime GeneratedDate { get; set; } = DateTime.Now;

    [NotMapped]
    public bool Valid 
    { 
        get { return Used == true || DateTime.Now > GeneratedDate.AddMinutes(30); } 
    }

    public LoginCode() { }

    public LoginCode(string code, string userId)
    {
        Code = code;
        UserId = userId;
    }
}
