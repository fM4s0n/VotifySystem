using Microsoft.AspNetCore.Identity;
using VotifySystem.Common.Classes;

namespace VotifySystem.Common.BusinessLogic.Services;

public interface IUserService
{
    event UserService.LogoutEventHandler LogOutEvent;
    event UserService.LoginEventHandler LogInEvent;

    /// <summary>
    /// Set the current user
    /// </summary>
    /// <param name="user">User to be set</param>
    void LogInUser(User user);

    /// <summary>
    /// Get the current user
    /// </summary>
    /// <returns>User object of the current user</returns>
    User? GetCurrentUser();

    /// <summary>
    /// Log out the current user
    /// </summary>
    void LogOutUser();

    /// <summary>
    /// Gets the UserLevel of the current user
    /// </summary>
    /// <returns>UserLevel value of current user if there is one, UserLevel.None otherwise</returns>
    UserLevel GetCurrentUserLevel();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    string HashPassword(User user, string password);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashedPassword"></param>
    /// <param name="unhashedPassword"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    PasswordVerificationResult VerifyPassword(string hashedPassword, string unhashedPassword, User user);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    string GenerateLoginCode();
}