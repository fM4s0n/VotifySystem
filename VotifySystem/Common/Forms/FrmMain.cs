using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Controls;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Controls;

namespace VotifySystem;

/// <summary>
/// Main form of the application
/// this is the main entry point of the application
/// </summary>
internal partial class frmMain : Form
{
    private IUserService? _userService;
    private IDbService? _dbService;

    ctrAdminHome? ctrAdminHome;
    ctrVoterHome? ctrVoterHome;

    private static frmMain _instance;
    public static frmMain GetInstance() { return _instance; }

    private UserLevel _mode = UserLevel.None;

    public frmMain(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;
        _dbService = dbService;

        Init();
    }

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        _userService!.LogOutEvent += UserService_LogOutEvent;
        _userService!.LogInEvent += UserService_LogInEvent;
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

        _dbService!.SeedDataIfRequired();
        SetMode();

        ctrMainDefault = new() { Parent = this };
        ctrMainDefault.Show();
    }

    /// <summary>
    /// Custom show method
    /// </summary>
    /// <param name="userService"></param>
    internal static void ShowForm(IUserService userService, IDbService dbService)
    {
        _instance = new frmMain(userService, dbService);
        Application.Run(_instance);
    }

    /// <summary>
    /// Handle the logout event by setting the mode to None
    /// </summary>
    private void UserService_LogOutEvent(object sender, EventArgs e)
    {
        SetMode();
    }

    /// <summary>
    /// Handle the login event by setting the mode of the form
    /// </summary>
    private void UserService_LogInEvent(object sender, EventArgs e)
    {
        SetMode();
    }

    /// <summary>
    /// Set the viewing mode of the form
    /// </summary>
    private void SetMode()
    {
        _mode = _userService!.GetCurrentUserLevel();
        SetVisibleControl();
    }

    /// <summary>
    /// Set the visible control based user level
    /// </summary>
    private void SetVisibleControl()
    {
        switch (_mode)
        {
            case UserLevel.Administrator:
                ctrAdminHome = new(_userService!){ Visible = true };
                ctrMainDefault.Visible = false;
                ctrAdminHome.Show();
                break;

            case UserLevel.Voter:
                ctrVoterHome = new() { Visible = true };
                ctrMainDefault.Visible = false;
                break;

            case UserLevel.None:
                ctrMainDefault.Visible = true;
                break;
        }
    }

    /// <summary>
    /// Handle any unhandled exceptions
    /// </summary>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Show in person login control
    /// </summary>
    internal void ShowInPersonLogin()
    {
        ctrLoginBase.Init(_userService!, _dbService!, LoginMode.InPerson);
        ctrLoginBase.Show();
        ctrMainDefault.Visible = false;
    }

    /// <summary>
    /// 
    /// </summary>
    internal void ShowOnlineLogin()
    {

    }
}
