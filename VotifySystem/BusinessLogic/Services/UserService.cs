using VotifySystem.Classes;
namespace VotifySystem.BusinessLogic.Services;

internal class UserService : IUserService
{
    private User? _currentUser = null;

    public User? GetCurrentUser()
    {
        return _currentUser;
    }

    public void SetCurrentUser(User user)
    {
        _currentUser = user;
    }
}
