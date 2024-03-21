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

        _userService.LogInEvent += UserService_LogInEvent;
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
    /// <param name="sender">Event senser</param>
    /// <param name="e">EventArgs</param>
    private void UserService_LogInEvent(object sender, EventArgs e)
    {
        ctrLoginInPerson.ResetControl();
        ctrLoginInPerson.Visible = false;
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