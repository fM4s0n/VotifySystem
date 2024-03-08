using VotifySystem.BusinessLogic.Services;
using VotifySystem.Classes;
using VotifySystem.Controls;
using VotifySystem.Forms;

namespace VotifySystem;

public partial class FrmMain : Form
{
    private readonly IUserService _userService;

    CtrAdminHome? ctrAdminHome;
    CtrVoterHome? ctrVoterHome;
    CtrLogin? ctrLogin;

    private UserLevel _mode = UserLevel.None;

    public FrmMain(IUserService userService)
    {
        InitializeComponent();

        _userService = userService;

        _userService.LogOutEvent += UserService_LogOutEvent;
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        SetMode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void UserService_LogOutEvent(object sender, EventArgs e)
    {
        SetMode();
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetMode()
    {
        _mode = _userService!.GetCurrentUserLevel();

        SetVisibleControl();
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetVisibleControl()
    {
        switch (_mode)
        {
            case UserLevel.Administrator:
                ctrAdminHome = new(_userService);
                pnlMain.Controls.Add(ctrAdminHome);
                break;

            case UserLevel.Voter:
                ctrVoterHome = new();
                pnlMain.Controls.Add(ctrVoterHome);
                break;

            case UserLevel.None:
                ctrLogin = new(_userService);
                pnlMain.Controls.Add(ctrLogin);
                break;
        }
    }


    /// <summary>
    /// Handle any unhandled exceptions
    /// </summary>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }
}
