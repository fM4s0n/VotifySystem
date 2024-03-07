using VotifySystem.Classes;

namespace VotifySystem.BusinessLogic.Services;

public interface IUserService
{ 
    void SetCurrentUser(User user);
    User? GetCurrentUser();   
}