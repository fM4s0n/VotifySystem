using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Controls;
public partial class ctrLoginBase : UserControl
{
    private IUserService? _userService;
    private IDbService? _dbService;

    private LoginMode _loginMode = LoginMode.InPerson;

    public ctrLoginBase() 
    { 
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="loginMode"></param>
    public void Init(IUserService userService, IDbService dbService,LoginMode loginMode)
    {
        _userService = userService;
        _dbService = dbService;
        _loginMode = loginMode;

        if (_loginMode == LoginMode.InPerson)
        {
            ctrLoginInPerson.Init(userService, dbService);
            ctrLoginInPerson.Visible = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    private void LoginUser(User user)
    {
        _userService!.LogInUser(user);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLogin_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSubmitLoginCode_Click(object sender, EventArgs e)
    {
        // check db or something
    }
}

/// <summary>
/// Mode to control which version of the control to show
/// </summary>
public enum LoginMode
{
    InPerson,
    Online
}