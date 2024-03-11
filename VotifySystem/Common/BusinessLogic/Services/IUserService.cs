using VotifySystem.Common.Classes;

namespace VotifySystem.Common.BusinessLogic.Services;

public interface IUserService
{
    event UserService.LogoutEventHandler LogOutEvent;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    void SetCurrentUser(User user);

    /// <summary>
    /// Get the current user
    /// </summary>
    /// <returns>User object of the current user</returns>
    User? GetCurrentUser();

    /// <summary>
    /// 
    /// </summary>
    void LogOut();
    UserLevel GetCurrentUserLevel();
}