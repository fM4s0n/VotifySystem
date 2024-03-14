using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Controls;
using VotifySystem.Controls;

namespace VotifySystem;

public partial class frmMain : Form
{
    private readonly IUserService _userService;

    CtrAdminHome? ctrAdminHome;
    ctrVoterHome? ctrVoterHome;
    ctrLoginBase? ctrLogin;
    private static frmMain _instance;
    public static frmMain GetInstance() { return _instance; }

    private UserLevel _mode = UserLevel.None;

    public frmMain(IUserService userService)
    {
        InitializeComponent();

        _userService = userService;

        Init();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Init()
    {
        _userService.LogOutEvent += UserService_LogOutEvent;
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        SetMode();

        pnlMain.Controls.Add(ctrMainDefault);
        ctrMainDefault = new() { Parent = this };
        ctrMainDefault.Show();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public static void ShowForm(IUserService userService)
    {
        _instance = new frmMain(userService);
        Application.Run(_instance);
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

    /// <summary>
    /// 
    /// </summary>
    public void ShowInPersonLogin()
    {
        ctrLogin = new(_userService, LoginMode.Online)
        {
            Enabled = true,
            Visible = true
        };

        ctrMainDefault.Visible = false;
        ctrLogin.Visible = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ShowOnlineLogin()
    {

    }
}
