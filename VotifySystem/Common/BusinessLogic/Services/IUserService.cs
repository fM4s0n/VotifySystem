using Microsoft.AspNetCore.Identity;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Classes;
using VotifySystem.Controls;

namespace VotifySystem.Common.BusinessLogic.Services;

public interface IUserService
{
    event UserService.LogoutEventHandler LogOutEvent;
    event UserService.LoginEventHandler LogInEvent;

    /// <summary>
    /// Log in the user and set the login mode
    /// </summary>
    /// <param name="user">User that has logged in</param>
    /// <param name="loginMode">InPerson or Online</param>
    void LogInUser(User user, LoginMode loginMode);

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
    PasswordVerificationResult VerifyPassword(string plainPassword, User user);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    LoginCode GenerateLoginCode();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    LoginMode GetLoginMode();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    string GetAppCultureCode();

    void SetAppLanguage(Country country);
}