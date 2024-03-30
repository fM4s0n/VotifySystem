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

        _userService.LogInEvent += UserService_LogInEvent;

        ctrLogin.Init(userService, dbService, loginMode);
        ctrLogin.Visible = true;       
    }

    /// <summary>
    /// Log in event
    /// </summary>
    private void UserService_LogInEvent(object sender, EventArgs e)
    {
        ctrLogin.ResetControl();
        ctrLogin.Visible = false;
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