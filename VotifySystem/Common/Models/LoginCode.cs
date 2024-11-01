﻿namespace VotifySystem.Common.Models;

/// <summary>
/// Class for unique login code.
/// Generated online to then be used once to login
/// </summary>
public class LoginCode
{
    public string Id { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public bool Used { get; set; } = false;
    public DateTime GeneratedDate { get; set; } = DateTime.Now;

    public bool GetValidity() 
    { 
       return Used == false && DateTime.Now < GeneratedDate.AddMinutes(30); 
    }

    public LoginCode() { }

    public LoginCode(string code, string userId)
    {
        Id = Guid.NewGuid().ToString();
        Code = code;
        UserId = userId;
    }
}
