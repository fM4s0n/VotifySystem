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
public partial class frmMain : Form
{
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;

    private static frmMain? _instance;
    public static frmMain GetInstance() { return _instance!; }

    private UserLevel _userLevelMode = UserLevel.None;
    private LoginMode _loginMode = LoginMode.InPerson;

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

        _dbService!.SeedData();
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
        _userLevelMode = _userService!.GetCurrentUserLevel();
        _loginMode = _userService!.GetLoginMode();
        SetVisibleControl();
    }

    /// <summary>
    /// Set the visible control based user level
    /// </summary>
    private void SetVisibleControl()
    {
        switch (_userLevelMode)
        {
            case UserLevel.Administrator:
                ctrMainDefault.Visible = false;
                ctrLoginBase.Visible = false;
                ctrAdminHome.Init(_userService!, _dbService!);
                ctrAdminHome.Visible = true;
                ctrAdminHome.Show();
                break;

            case UserLevel.Voter:
                ctrMainDefault.Visible = false;
                ctrLoginBase.Visible = false;
                if (_loginMode == LoginMode.InPerson)
                {
                    ctrVoterHome.Init(_userService!, _dbService!);
                    ctrVoterHome.Visible = true;
                    ctrVoterHome.Show();
                }
                else
                {
                    ctrVoterHomeOnline.Init(_userService!, _dbService!);
                    ctrVoterHomeOnline.Visible = true;
                    ctrVoterHomeOnline.Show();
                }
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
    /// Show the online login control
    /// </summary>
    internal void ShowOnlineLogin()
    {
        ctrLoginBase.Init(_userService!, _dbService!, LoginMode.Online);
        ctrLoginBase.Show();
        ctrMainDefault.Visible = false;
    }
}
