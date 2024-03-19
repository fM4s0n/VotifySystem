using VotifySystem.Common.Classes;

namespace VotifySystem.Common.BusinessLogic.Services;

public interface IUserService
{
    event UserService.LogoutEventHandler LogOutEvent;

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
    string HashPassword(User user, string password);
}