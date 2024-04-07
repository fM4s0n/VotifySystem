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
    /// Hash password 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns>string of hashed plaintext password</returns>
    string HashPassword(User user, string password);

    /// <summary>
    /// Verify the user password is correct
    /// </summary>
    /// <param name="plainPassword"></param>
    /// <param name="user"></param>
    /// <returns>Failed or successful verification of password input </returns>
    PasswordVerificationResult VerifyPassword(string plainPassword, User user);

    /// <summary>
    /// Generates a random 6 digit login code
    /// </summary>
    /// <returns>New object of LoginCode</returns>
    LoginCode GenerateLoginCode();

    /// <summary>
    /// Gets the login mode set by the user
    /// In person or online
    /// </summary>
    /// <returns></returns>
    LoginMode GetLoginMode();

    /// <summary>
    /// Gets the app-wide language
    /// </summary>
    /// <returns></returns>
    string GetAppCultureCode();

    /// <summary>
    /// Sets the app-wide language
    /// </summary>
    /// <param name="country">Country enum of the language</param>
    void SetAppLanguage(Country country);

    /// <summary>
    /// Get a user by their username
    /// </summary>
    /// <param name="username">username</param>
    /// <returns>User object of found user if found, null if not </returns>
    User? GetUserByUsername(string username);

    /// <summary>
    /// Get a user by their id
    /// </summary>
    /// <param name="id">user id</param>
    /// <returns>User object of found user if found, null if not </returns>
    User? GetUserById(string id);

    /// <summary>
    /// Gets all users in the database
    /// </summary>
    /// <returns>List of users</returns>
    List<User>? GetAllUsers();

    /// <summary>
    /// Gets all voters in the database
    /// </summary>
    /// <returns>List of voters</returns>
    List<User>? GetAllVoters();

    /// <summary>
    /// Gets all administrators in the database
    /// </summary>
    /// <returns>A list of all admins</returns>
    List<User>? GetAllAdministrators();

    /// <summary>
    /// Adds a new user to the database
    /// </summary>
    /// <param name="user"></param>
    void InsertUser(User user);

    /// <summary>
    /// Updates a user in the database
    /// </summary>
    /// <param name="user"></param>
    void UpdateUser(User user);

    /// <summary>
    /// Deletes a user from the database
    /// </summary>
    /// <param name="user"></param>
    void DeleteUser(User user);

    /// <summary>
    /// Gets all login codes in the database
    /// </summary>
    List<LoginCode>? GetAllLoginCodes();

    /// <summary>
    /// gets a login code by its code
    /// </summary>
    /// <param name="code"></param>
    LoginCode? GetLoginCodeByCode(string code);
    
    /// <summary>
    /// adds a login code to the database
    /// </summary>
    /// <param name="loginCode">New LoginCode to be added</param>
    void InsertLoginCode(LoginCode loginCode); 
}