using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Controls;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Controls;

namespace VotifySystem;

internal partial class frmMain : Form
{
    private readonly IUserService _userService;
    private readonly IDbService _dbService;

    CtrAdminHome? ctrAdminHome;
    ctrVoterHome? ctrVoterHome;

    private static frmMain _instance;
    public static frmMain GetInstance() { return _instance; }

    private UserLevel _mode = UserLevel.None;

    public frmMain(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        _userService = userService;
        _dbService = dbService;

        Init();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Init()
    {
        _userService.LogOutEvent += UserService_LogOutEvent;
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

        CheckForDefaultAdmin();

        SetMode();

        ctrMainDefault = new() { Parent = this };
        ctrMainDefault.Show();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CheckForDefaultAdmin()
    {
        if (_dbService.GetDatabaseContext().Administrators.Any(a => a.Username == "DefaultAdmin") == false)
        {
            _dbService.InsertEntity(UserHelper.CreateInitialAdministrator());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    internal static void ShowForm(IUserService userService, IDbService dbService)
    {
        _instance = new frmMain(userService, dbService);
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
    internal void SetMode()
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
                //pnlMain.Controls.Add(ctrAdminHome);
                break;

            case UserLevel.Voter:
                ctrVoterHome = new();
                //pnlMain.Controls.Add(ctrVoterHome);
                break;

            case UserLevel.None:
                //pnlMain.Controls.Add(ctrLogin);
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
    internal void ShowInPersonLogin()
    {
        ctrLoginBase.Init(_userService, LoginMode.InPerson);
        ctrLoginBase.Show();
        ctrMainDefault.Visible = false;
    }

    /// <summary>
    /// 
    /// </summary>
    internal void ShowOnlineLogin()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    internal void ShowAdminLogin()
    {
        
    }
}
