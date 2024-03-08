using VotifySystem.BusinessLogic.Services;
using VotifySystem.Classes;

namespace VotifySystem.Controls;
public partial class CtrLogin : UserControl
{
    IUserService _userService;

    /// <summary>
    /// Constructor for Login Control
    /// </summary>
    /// <param name="userService">Singleton User Service</param>
    public CtrLogin(IUserService userService)
    {
        InitializeComponent();

        _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    private void LoginUser(User user)
    {
        _userService.SetCurrentUser(user);
    }
}
