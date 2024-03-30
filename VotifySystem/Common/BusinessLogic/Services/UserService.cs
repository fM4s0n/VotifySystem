using Microsoft.AspNetCore.Identity;

using VotifySystem.Common.Classes;
using VotifySystem.Controls;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Singleton User Service
/// </summary>
public class UserService : IUserService
{
    private User? _currentUser = null;
    private LoginMode _loginMode = LoginMode.InPerson;

    // Define the public delegates for login and logout events
    public delegate void LogoutEventHandler(object sender, EventArgs e);
    public delegate void LoginEventHandler(object sender, EventArgs e);

    // Define the public events for login and logout events
    public event LogoutEventHandler? LogOutEvent;
    public event LoginEventHandler? LogInEvent;

    /// <summary>
    /// Get the current user
    /// </summary>
    /// <returns>User object of the current user</returns>
    public User? GetCurrentUser() => _currentUser;

    /// <summary>
    /// Get Current user's UserLevel
    /// </summary>
    /// <returns>UserLevel of current user</returns>
    public UserLevel GetCurrentUserLevel()
    {
        if (_currentUser == null)
            return UserLevel.None;

        return _currentUser.UserLevel;
    }

    /// <summary>
    /// Log in the user and set the login mode
    /// </summary>
    /// <param name="user">User that has logged in</param>
    /// <param name="loginMode">InPerson or Online</param>
    public void LogInUser(User user, LoginMode loginMode) 
    { 
        _loginMode = loginMode;
        _currentUser = user; 
        OnLogin();
    }

    /// <summary>
    /// Logout event
    /// </summary>
    public void LogOutUser()
    {
        _currentUser = null;
        OnLogout();
    }

    /// <summary>
    /// Login Event
    /// </summary>
    public void OnLogin() => LogInEvent?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Logout Event
    /// </summary>
    public void OnLogout() => LogOutEvent?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Hash password 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns>string of hashed plaintext password</returns>
    public string HashPassword(User user, string password)
    {
        PasswordHasher<User> passwordHasher = new();
        return passwordHasher.HashPassword(user, password);
    }

    /// <summary>
    /// Verify the user password is correct
    /// </summary>
    /// <param name="hashedPassword"></param>
    /// <param name="unhashedPassword"></param>
    /// <param name="user"></param>
    /// <returns>Failed or successful verification of password input </returns>
    public PasswordVerificationResult VerifyPassword(string hashedPassword, string unhashedPassword, User user)
    {
        PasswordHasher<User> passwordHasher = new();
        return passwordHasher.VerifyHashedPassword(user, hashedPassword, unhashedPassword);
    }

    /// <summary>
    /// Generates a random 6 digit login code
    /// </summary>
    /// <returns>New object of LoginCode</returns>
    public LoginCode GenerateLoginCode() => new(Guid.NewGuid().ToString()[..6], _currentUser!.Id);

    public LoginMode GetLoginMode() => _loginMode;
}
