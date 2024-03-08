using VotifySystem.Classes;

namespace VotifySystem.BusinessLogic.Services;

/// <summary>
/// Singleton User Service
/// </summary>
public class UserService : IUserService
{
    private User? _currentUser = null;

    // Define a public delegate for the logout event
    public delegate void LogoutEventHandler(object sender, EventArgs e);

    // Use the public delegate as the event type
    public event LogoutEventHandler LogOutEvent;

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
    /// Set the current user
    /// </summary>
    /// <param name="user">User object of the user to be set</param>
    public void SetCurrentUser(User user) => _currentUser = user;

    /// <summary>
    /// 
    /// </summary>
    public void LogOut() => OnLogout();

    /// <summary>
    /// Logout Event
    /// </summary>
    public virtual void OnLogout() => LogOutEvent?.Invoke(this, EventArgs.Empty);
}
